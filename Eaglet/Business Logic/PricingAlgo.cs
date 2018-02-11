using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaglet.Business_Logic
{
    public class PricingAlgo
    {
        private static double[,] RandomNumbers;

        //Algo to Calculate Random Number from previous projects
        public static void GenerateRandomNumbers(int trials, int steps)
        {
            Random rnd = new Random();
            double x1, x2, z1, z2, c, w;
            double[,] matrix = new double[trials, steps - 1];

            for (int i = 0; i < trials; i++)
            {
                for (int j = 0; j < steps-1; j++)
                {
                    do
                    {
                        x1 = 2 * rnd.NextDouble() - 1;
                        x2 = 2 * rnd.NextDouble() - 1;
                        w = Math.Pow(x1, 2) + Math.Pow(x2, 2);
                    } while (w > 1);

                    c = Math.Sqrt((-2) * Math.Log(w) / w);
                    z1 = c * x1;
                    z2 = c * x2;

                    matrix[i, j] = z1;
                }
            }

            RandomNumbers = matrix;
        }

        //Algo to Generate Simulation using M.C Method
        public static double[,] GenerateSimulation(int steps, int trials, double s, double t, double sig, double r)
        {
            double[,] simulation = new double[trials, steps];
            //double[,] randomNumbers = GenerateRandomNumbers(trials, steps);

            if (RandomNumbers == null)
            {
                GenerateRandomNumbers(trials, steps);
            }

            double timeIncrement = Convert.ToDouble(t / (steps - 1));

            try
            {
                for (int i = 0; i < trials; i++)
                {
                    simulation[i, 0] = s;

                    for (int j = 1; j < steps; j++)
                    {
                        simulation[i, j] = simulation[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                            sig * Math.Sqrt(timeIncrement) * RandomNumbers[i, j - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            

            return simulation;
        }

        //Algo to Calculate Call/Put Prices during M.C Simulaiton
        public static Dictionary<string, double> GetPrices(int steps, int trials, double s, double k, double t,  double sig, double r)
        {
            double [,] simulation = GenerateSimulation(steps, trials, s, t, sig, r);
            double [] totalPrices = new double [2];
            Dictionary<string, double> prices = new Dictionary<string, double>();

            for (int i = 0; i < trials; i++)
            {
                totalPrices[0] = totalPrices[0] + Math.Max(simulation[i, steps - 1] - k, 0);
                totalPrices[1] = totalPrices[1] + Math.Max(k - simulation[i, steps - 1], 0);
            }

            prices.Add("call", totalPrices[0] / trials);
            prices.Add("put", totalPrices[1] / trials);

            return prices;
        }       

        public static DataTable SetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Parameters", typeof(string));
            table.Columns.Add("Call", typeof(double));
            table.Columns.Add("Put", typeof(double));

            table.Rows.Add("Thoretical Price", null, null);
            table.Rows.Add("Delta", null, null);
            table.Rows.Add("Gamma", null, null);
            table.Rows.Add("Theta", null, null);
            table.Rows.Add("Rho", null, null);
            table.Rows.Add("Vega", null, null);

            return table;
        }

        public static DataTable GetDataTable(int steps, int trials, double s, double k, double t, double sig, double r, double estimateLevel = 0.01)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Parameters", typeof(string));
            table.Columns.Add("Call", typeof(double));
            table.Columns.Add("Put", typeof(double));

            double sHigh = s * (1 + estimateLevel), sLow = s * (1 - estimateLevel);
            double tHigh = t * (1 + estimateLevel);
            double rHigh = r * (1 + estimateLevel*2), rLow = r * (1 - estimateLevel*2);
            double sigHigh = sig * (1 + estimateLevel), sighLow = sig * (1 - estimateLevel);

            #region Price
            Dictionary<string, double> prices = GetPrices(steps, trials, s, k, t, sig, r);
            double callPrice = prices["call"];
            double putPrice = prices["put"];
            //double callPrice = GetCallPrice(steps, trials, s, k, t, sig, r);
            //double putPrice = GetPutPrice(steps, trials, s, k, t, sig, r);
            #endregion


            #region Delta 
            Dictionary<string, double> highUnderlytingPrices = GetPrices(steps, trials, sHigh, k, t, sig, r);
            double highUnderlyingCallPrice = highUnderlytingPrices["call"], highUnderlyingPutPrice = highUnderlytingPrices["put"];

            Dictionary<string, double> lowUnderlyingPrices = GetPrices(steps, trials, sLow, k, t, sig, r);
            double lowUnderlyingCallPrice = lowUnderlyingPrices["call"], lowUnderlyingPutPrice = lowUnderlyingPrices["put"];

            //Formula to Calculate Delta referenced from class notes: dc/ds
            double callDelta = (highUnderlyingCallPrice - callPrice) / (estimateLevel * s);
            double putDelta = (highUnderlyingPutPrice - putPrice) / (estimateLevel * s);             
            #endregion

            #region Gamma 
            //Formula to Calculate Gamma referencing class notes: d^2c/ds^2
            double callGamma = (highUnderlyingCallPrice - 2 * callPrice + lowUnderlyingCallPrice) / (Math.Pow(estimateLevel * s, 2));           
            double putGamma = (highUnderlyingPutPrice - 2 * putPrice + lowUnderlyingPutPrice) / (Math.Pow(estimateLevel * s, 2));
            #endregion  

            #region Theta
            Dictionary<string, double> highTPrices = GetPrices(steps, trials, s, k, tHigh, sig, r);
            double highTCallPrice = highTPrices["call"], highTPutPrice = highTPrices["put"];

            //Formula to calculate Theta referencing class notes: dc/dt
            double callTheta = -(highTCallPrice - callPrice) / (estimateLevel * t);                 
            double putTheta = -(highTPutPrice - putPrice) / (estimateLevel * t);
            #endregion

            //#region Rho
            //esiteamteLevel = 0.01
            //double rHigh = r * (1 + estimateLevel * 2), rLow = r * (1 - estimateLevel * 2);
            Dictionary<string, double> highRPrices = GetPrices(steps, trials, s, k, t, sig, rHigh);
            double highRCallPrice = highRPrices["call"], highRPutPrice = highRPrices["put"];

            Dictionary<string, double> lowRPrices = GetPrices(steps, trials, s, k, t, sig, rLow);
            double lowRCallPrice = lowRPrices["call"], lowRPutPrice = lowRPrices["put"];

            double callRho = (highRCallPrice - lowRCallPrice) / (2 * estimateLevel*2 * r);
            double putRho = (highRPutPrice - lowRPutPrice) / (2 * estimateLevel*2 * r);
            //double callRho = (GetCallPrice(steps, trials, s, k, t, sig, rHigh) - GetCallPrice(steps, trials, s, k, t, sig, rLow)) /
            //    (2 * estimateLevel * r);

            //double putRho = (GetPutPrice(steps, trials, s, k, t, sig, rHigh) - GetPutPrice(steps, trials, s, k, t, sig, rLow)) /
            //    (2 * estimateLevel * r);
            //#endregion

            //#region Vega           
            Dictionary<string, double> highSigPrices = GetPrices(steps, trials, s, k, t, sigHigh, r);
            double highSigCallPrice = highSigPrices["call"], highSigPutPrice = highSigPrices["put"];

            Dictionary<string, double> lowSigPrices = GetPrices(steps, trials, s, k, t, sighLow, r);
            double lowSigCallPrice = lowSigPrices["call"], lowSigPutPrice = lowSigPrices["put"];

            double callVega = (highSigCallPrice - lowSigCallPrice) / (2 * estimateLevel * sig);
            double putVega = (highSigPutPrice - lowSigPutPrice) / (2 * estimateLevel * sig);
            //double callVega = (GetCallPrice(steps, trials, s, k, t, sigHigh, r) - GetCallPrice(steps, trials, s, k, t, sighLow, r)) /
            //    (2 * estimateLevel * sig);

            //double putVega = (GetPutPrice(steps, trials, s, k, t, sigHigh, r) - GetPutPrice(steps, trials, s, k, t, sighLow, r)) /
            //    (2 * estimateLevel * sig);
            //#endregion

            table.Rows.Add("Thoretical Price", callPrice, putPrice);
            table.Rows.Add("Delta", callDelta, putDelta);
            //table.Rows.Add("Gamma", callGamma, putGamma);
            table.Rows.Add("Theta", callTheta, putTheta);
            table.Rows.Add("Rho", callRho, putRho);
            table.Rows.Add("Vega", callVega, putVega);

            //reset RandomNumbers after each Pricing Request
            RandomNumbers = null;

            return table;

        }









        //useful for later project
        //#region Black-Scholes Parameters
        ////Black-Scholes Formula 
        //double d1 = (Math.Log(s / k) + t * (r - 0 + (Math.Pow(sig, 2) / 2))) / (sig * Math.Sqrt(t));
        //double d2 = d1 - sig * Math.Sqrt(t);
        //#endregion
        ////Algo to calcualte Call/Put Prices using M.C. Simulation
        //public static double GetCallPrice(double s, double k, double t, int steps, int trials, double sig, double r)
        //{
        //    double[,] simulation = new double[steps, trials];
        //    double[,] randomNumbers = GenerateRandomNumbers(steps, trials);
        //    double timeIncrement = Convert.ToDouble(t / (steps - 1));
        //    double totalCallPrice = 0;

        //    for (int i = 0; i < trials; i++)
        //    {
        //        simulation[i, 0] = s;

        //        for (int j = 0; j < steps - 1; j++)
        //        {
        //            simulation[i, j] = simulation[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
        //                sig * Math.Sqrt(timeIncrement) * randomNumbers[i, j - 1]);
        //        }
        //    }

        //    for (int i = 0; i < trials; i++)
        //    {
        //        totalCallPrice = totalCallPrice + Math.Max(simulation[i, steps - 1] - k, 0);                
        //    }

        //    double callPrice = totalCallPrice / trials;

        //    return callPrice;
        //}

        //public static double GetPutPrice(double s, double k, double t, int steps, int trials, double sig, double r)
        //{
        //    double[,] simulation = new double[steps, trials];
        //    double[,] randomNumbers = GenerateRandomNumbers(steps, trials);
        //    double timeIncrement = Convert.ToDouble(t / (steps - 1));
        //    double totalPutPrice = 0;

        //    for (int i = 0; i < trials; i++)
        //    {
        //        simulation[i, 0] = s;

        //        for (int j = 0; j < steps - 1; j++)
        //        {
        //            simulation[i, j] = simulation[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
        //                sig * Math.Sqrt(timeIncrement) * randomNumbers[i, j - 1]);
        //        }
        //    }

        //    for (int i = 0; i < trials; i++)
        //    {
        //        totalCallPrice = totalCallPrice + Math.Max(simulation[i, steps - 1] - k, 0);
        //    }

        //    double callPrice = totalCallPrice / trials;

        //    return callPrice;
        //}
        ////Algo to calculate Greeks




        //public static Dictionary<string, double> GetPrices(double s, double k, double t, int steps, int trials, double sig, double r)
        //{
        //    double[,] simulation = new double[steps, trials];
        //    double[,] randomNumbers = GenerateRandomNumbers(steps, trials);
        //    double timeIncrement = Convert.ToDouble(t / (steps - 1));

        //    double totalCallPrice = 0, totalPutPrice = 0;
        //    Dictionary<string, double> optionPrices = new Dictionary<string, double>();

        //    for (int i = 0; i < trials; i++)
        //    {
        //        simulation[i, 0] = s;

        //        for (int j = 0; j < steps-1; j++)
        //        {
        //            simulation[i, j] = simulation[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
        //                sig * Math.Sqrt(timeIncrement) * randomNumbers[i, j - 1]);
        //        }
        //    }

        //    for (int i = 0; i < trials; i++)
        //    {
        //        totalCallPrice = totalCallPrice + Math.Max(simulation[i, steps - 1] - k, 0);
        //        totalPutPrice = totalPutPrice + Math.Max(k - simulation[i, steps - 1], 0);
        //    }

        //    double callPrice = totalCallPrice / trials, putPrice = totalPutPrice / trials;

        //    optionPrices.Add("callPrice", callPrice);
        //    optionPrices.Add("putPrice", putPrice);

        //    return optionPrices;

        //}

        //public static void CalculateGreeks(double s, double k, double t, int steps, int trials, double sig, double r, double estimateLevel = 0.01)
        //{
        //    double sHigh = s * (1 + estimateLevel), sLow = s * (1 - estimateLevel);
        //    double tHigh = t * (1 + estimateLevel);
        //    double rHigh = r * (1 + estimateLevel), rLow = r * (1 - estimateLevel);
        //    double sigHigh = sig * (1 + estimateLevel), sighLow = sig * (1 - estimateLevel);



        //    double delta = (GetPrices(sHigh, k, t, steps, trials, sig, r) - GetPrices(sLow, k, t, steps, trials, sig, r))
        //        / (2 * estimateLevel * s);


        //}
    }
}
