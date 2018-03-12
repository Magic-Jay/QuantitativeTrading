using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fledgling2.Business_Logic
{
    public class PricingAlgo
    {
        private static double[,] RandomNumbers;
        public static double AlgoTime;

        //Set VarianceReduction Option
        public static Dictionary<string, bool> VaraianceReductionOptions = new Dictionary<string, bool>()
        {
            {"Antithetic_Variance_Reduction", false },
            {"Control_Variate", false },
            {"MultiThread",false }
        };
       
        public static string log = "";

        //Algo to Calculate Random Number from previous projects
        public static void GenerateRandomNumbers(int trials, int steps)
        {
            Random rnd = new Random();
            double x1, x2, z1, z2, c, w;
            double[,] matrix = new double[trials, steps - 1];

            try
            {
                for (int i = 0; i < trials; i++)
                {
                    for (int j = 0; j < steps - 1; j++)
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
            }
            catch (Exception ex )
            {

                log = ex.Message + " at GenerateRandomNumbers()";
            }
           
            RandomNumbers = matrix;
        }

        #region Monte Carlo Simulation
        //Algo to Generate Simulation using M.C Method

        #region old
        //public static Dictionary<string, double[,]> GenerateSimulation(int steps, int trials, double s, double k, double t, double sig, double r)
        //{
        //    Dictionary<string, double[,]> simulations = new Dictionary<string, double[,]>();
        //    double[,] simulation = new double[trials, steps];
        //    double[,] controlVariatePathCall = new double[trials, steps];
        //    var controlVariate = VaraianceReductionOptions["Control_Variate"];
        //    double tHedge, delta;

        //    if (RandomNumbers == null)
        //    {
        //        GenerateRandomNumbers(trials, steps);
        //    }

        //    double timeIncrement = Convert.ToDouble(t / (steps - 1));

        //    try
        //    {
        //        //Formula to genearte simulation referenced from lecture notes
        //        for (int i = 0; i < trials; i++)
        //        {
        //            simulation[i, 0] = s;
        //            controlVariatePathCall[i, 0] = 0;

        //            for (int j = 1; j < steps; j++)
        //            {
        //                simulation[i, j] = simulation[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
        //                    sig * Math.Sqrt(timeIncrement) * RandomNumbers[i, j - 1]);

        //                if (controlVariate)
        //                {
        //                    tHedge = (i - 1) * timeIncrement;
        //                    delta = BlackScholesDeltas(s, k, t, tHedge, sig, r);
        //                    controlVariatePathCall[i, j] = controlVariatePathCall[i, j - 1] + 
        //                        delta * (simulation[i, j] - simulation[i, j - 1] * Math.Exp(r * timeIncrement));//Delta Hedge
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log = ex.Message + " at GenerateSimulation()";
        //    }

        //    simulations.Add("simulationRegular", simulation);
        //    simulations.Add("controlVariatePathCall", controlVariatePathCall);
        //    return simulations;
        //}

        ////Algo to Generate Simulation using M.C Antithetic Variance Reduction
        //public static Dictionary<string, double[,]> GenerateAntiTheticSimulation(int steps, int trials, double s, double k, double t, double sig, double r)
        //{
        //    Dictionary<string, double[,]> simulations = new Dictionary<string, double[,]>();
        //    double[,] simulationRegular = new double[trials, steps], simulationAtithetic = new double[trials, steps], 
        //        controlVariatePathAntiThetic = new double[trials, steps];
        //    var controlVariate = VaraianceReductionOptions["Control_Variate"];
        //    double tHedge, delta;

        //    if (RandomNumbers == null)
        //    {
        //        GenerateRandomNumbers(trials, steps);
        //    }

        //    double timeIncrement = Convert.ToDouble(t / (steps - 1));

        //    try
        //    {
        //        //Formula to genearte simulation using antithetic method referenced from lecture notes
        //        for (int i = 0; i < trials; i++)
        //        {
        //            simulationRegular[i, 0] = s;
        //            simulationAtithetic[i, 0] = s;
        //            controlVariatePathAntiThetic[i, 0] = 0;

        //            for (int j = 1; j < steps; j++)
        //            {                       
        //                simulationRegular[i, j] = simulationRegular[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
        //                    sig * Math.Sqrt(timeIncrement) * RandomNumbers[i, j - 1]);

        //                simulationAtithetic[i, j] = simulationAtithetic[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
        //                    sig * Math.Sqrt(timeIncrement) * (-1) * RandomNumbers[i, j - 1]);

        //                if (controlVariate)
        //                {
        //                    tHedge = (i - 1) * timeIncrement;
        //                    delta = BlackScholesDeltas(s, k, t, tHedge, sig, r);
        //                    controlVariatePathAntiThetic[i, j] = controlVariatePathAntiThetic[i, j - 1] + delta * 
        //                        (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
        //                }

        //            }

        //        }

        //    }
        //    catch (Exception ex)    
        //    {
        //        log = ex.Message + " at GenerateAntiTheticSimulation()";
        //    }

        //    simulations.Add("regular", simulationRegular);
        //    simulations.Add("antithetic", simulationAtithetic);
        //    simulations.Add("controlVariateAntiThetic", controlVariatePathAntiThetic);

        //    return simulations;
        //}
#endregion
        public static Dictionary<string, double[,]> GenerateSimulations(int steps, int trials, double s, double k, double t, double sig, double r)
        {
            Dictionary<string, double[,]> simulations = new Dictionary<string, double[,]>();
            double[,] simulationRegular = new double[trials, steps], simulationAtithetic = new double[trials, steps];
            double[,] controlVariatePathCall = new double[trials, steps], controlVariatePathPut = new double[trials, steps];
            double[,] controlVariatePathAntiTheticCall = new double[trials, steps], controlVariatePathAntiTheticPut = new double[trials, steps];
            double tHedge, deltaCall, deltaPut;
            double timeIncrement = Convert.ToDouble(t / (steps - 1));

            var controlVariate = VaraianceReductionOptions["Control_Variate"];
            var antithetic = VaraianceReductionOptions["Antithetic_Variance_Reduction"];
            

            if (RandomNumbers == null)
            {
                GenerateRandomNumbers(trials, steps);
            }            

            try
            {
                //Formula to genearte simulation using antithetic method referenced from lecture notes
                for (int i = 0; i < trials; i++)
                {
                    simulationRegular[i, 0] = s;
                    simulationAtithetic[i, 0] = s;
                    controlVariatePathCall[i, 0] = 0;
                    controlVariatePathPut[i, 0] = 0;
                    controlVariatePathAntiTheticCall[i, 0] = 0;
                    controlVariatePathAntiTheticPut[i, 0] = 0;

                    for (int j = 1; j < steps; j++)
                    {
                        tHedge = (i - 1) * timeIncrement;
                        deltaCall = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                        deltaPut = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                        
                        simulationRegular[i, j] = simulationRegular[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                            sig * Math.Sqrt(timeIncrement) * RandomNumbers[i, j - 1]);

                        if (controlVariate)
                        {                            
                            controlVariatePathCall[i, j] = controlVariatePathCall[i, j - 1] + deltaCall *
                                (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                            controlVariatePathPut[i, j] = controlVariatePathPut[i, j - 1] + deltaPut *
                                (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                        }

                        if (antithetic)
                        {
                            simulationAtithetic[i, j] = simulationAtithetic[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                            sig * Math.Sqrt(timeIncrement) * (-1) * RandomNumbers[i, j - 1]);

                            if (controlVariate)
                            {
                                //tHedge = (i - 1) * timeIncrement;
                                //deltaCall = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                                //deltaPut = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaPut"];
                                controlVariatePathAntiTheticCall[i, j] = controlVariatePathAntiTheticCall[i, j - 1] + deltaCall *
                                    (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathAntiTheticPut[i, j] = controlVariatePathAntiTheticPut[i, j - 1] + deltaPut *
                                    (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
                            }
                        }                                              
                    }

                }

            }
            catch (Exception ex)
            {
                log = ex.Message + " at GenerateAntiTheticSimulation()";
            }

            simulations.Add("regular", simulationRegular);
            simulations.Add("antithetic", simulationAtithetic);
            simulations.Add("controlVariatePathCall", controlVariatePathCall);
            simulations.Add("controlVariatePathPut", controlVariatePathPut);
            simulations.Add("controlVariatePathAntiTheticCall", controlVariatePathAntiTheticCall);
            simulations.Add("controlVariatePathAntiTheticPut", controlVariatePathAntiTheticPut);

            return simulations;
        }

        //Algo to Calculate Deltas From Black-Scholes Formula
        public static Dictionary<string, double> BlackScholesDeltas(double s, double k, double t, double tHedge, double sig, double r)
        {
            Dictionary<string, double> deltas = new Dictionary<string, double>();
            //Calculate d1 from Black-Sholes Formula
            double d = (Math.Log(s / k) + (r + (sig * sig) / 2) / (t - tHedge)) / (sig * Math.Sqrt(t));
            double deltaCall = CumulativeNormalDistribution(d);
            double deltaPut = CumulativeNormalDistribution(d) - 1;

            deltas.Add("deltaCall", deltaCall);
            deltas.Add("deltaPut", deltaPut);
   
            return deltas;
        }

        //Algo to Implement Cumulative Normal Function, referenced from http://www.johndcook.com/blog/cpp_phi/
        public static double CumulativeNormalDistribution(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
        #endregion

        //Algo to Calculate Call/Put Prices during M.C Simulaiton
        public static Dictionary<string, double> GetPrices(int steps, int trials, double s, double k, double t,  double sig, double r)
        {
            #region Prices
            Dictionary<string, double> prices = new Dictionary<string, double>();
            double totalCallPrice = 0, totalPutPrice = 0, callPrice = 0, putPrice = 0;
            double[,] pricesByTrial = new double[2, trials];            
            var antithetic = VaraianceReductionOptions["Antithetic_Variance_Reduction"];
            var controlVariate = VaraianceReductionOptions["Control_Variate"];

            var simulations = GenerateSimulations(steps, trials, s, k, t, sig, r);
            var simulationRegular = simulations["regular"];
            var simulationAtithetic = simulations["antithetic"];
            var controlVariatePathCall = simulations["controlVariatePathCall"];
            var controlVariatePathPut = simulations["controlVariatePathPut"];
            var controlVariatePathAntiTheticCall = simulations["controlVariatePathAntiTheticCall"];
            var controlVariatePathAntiTheticPut = simulations["controlVariatePathAntiTheticPut"];
                  
            try
            {
                if (!antithetic)
                {                    
                    //Formulat to Calculate Call/Put Price referenced from Lecture Notes
                    for (int i = 0; i < trials; i++)
                    {
                        if (controlVariate)
                        {
                            pricesByTrial[0, i] = Math.Max(simulationRegular[i, steps - 1] - k, 0) - controlVariatePathCall[i, steps - 1];
                            pricesByTrial[1, i] = Math.Max(k - simulationRegular[i, steps - 1], 0) - controlVariatePathPut[i, steps - 1];
                        }
                        else
                        {
                            //Save simulated prices for variance calcualtion
                            pricesByTrial[0, i] = Math.Max(simulationRegular[i, steps - 1] - k, 0);
                            pricesByTrial[1, i] = Math.Max(k - simulationRegular[i, steps - 1], 0);
                        }

                        totalCallPrice = totalCallPrice + pricesByTrial[0, i];
                        totalPutPrice = totalPutPrice + pricesByTrial[1, i];
                    }

                    ////Formula to Calcualte Simulation Option Price referenced from Lecture Notes: SUM/Trials * Discount_Factor
                    //callPrice = totalCallPrice / trials * Math.Exp(-r * t);
                    //putPrice = totalPutPrice / trials * Math.Exp(-r * t);
                    //prices.Add("call", callPrice);
                    //prices.Add("put", putPrice);


                }
                else
                {                    
                    for (int i = 0; i < trials; i++)
                    {
                        if (controlVariate)
                        {
                            pricesByTrial[0, i] = 0.5 * (Math.Max(simulationRegular[i, steps - 1] - k, 0) - controlVariatePathCall[i, steps - 1]
                                + Math.Max(simulationAtithetic[i, steps - 1] - k, 0) - controlVariatePathAntiTheticCall[i, steps - 1]);

                            pricesByTrial[1, i] = 0.5 * (Math.Max(k - simulationRegular[i, steps - 1], 0) - controlVariatePathPut[i, steps - 1] 
                                + Math.Max(k - simulationAtithetic[i, steps - 1], 0) - controlVariatePathAntiTheticPut[i, steps - 1]);
                        }
                        else
                        {
                            //Save simulated prices for variance calcualtion
                            pricesByTrial[0, i] = 0.5 * (Math.Max(simulationRegular[i, steps - 1] - k, 0) +
                            Math.Max(simulationAtithetic[i, steps - 1] - k, 0));

                            pricesByTrial[1, i] = 0.5 * (Math.Max(k - simulationRegular[i, steps - 1], 0) +
                                Math.Max(k - simulationAtithetic[i, steps - 1], 0));

                        }

                        totalCallPrice = totalCallPrice + pricesByTrial[0, i];
                        totalPutPrice = totalPutPrice + pricesByTrial[1, i];
                    }

                    ////Formula to Calcualte Simulation Option Price referenced from Lecture Notes: SUM/Trials * Discount_Factor
                    //callPrice = totalCallPrice / trials * Math.Exp(-r * t);
                    //putPrice = totalPutPrice / trials * Math.Exp(-r * t);
                    //prices.Add("call", callPrice);
                    //prices.Add("put", putPrice);
                }

                //Formula to Calcualte Simulation Option Price referenced from Lecture Notes: SUM/Trials * Discount_Factor
                callPrice = totalCallPrice / trials * Math.Exp(-r * t);
                putPrice = totalPutPrice / trials * Math.Exp(-r * t);
                prices.Add("call", callPrice);
                prices.Add("put", putPrice);
            }
            catch (Exception ex)
            {

                log = ex.Message + "at GetPrices() for calcualting prices.";
            }
                                                         
            #endregion
            
            #region Variance/Standard Error
            double callSumDifference = 0, putSumDifference = 0;
            double callStandardDeviation, putStandardDeviation;
            double callStandardError, putStandardError;

            try
            {
                //Formula to Calcualte StandardDeviation, StandardError from class notes: SD = Sqrt(1/(m-1) * Sum(C(0,j) - C0)^2) SE = SD/Sqrt(m)
                for (int i = 0; i < trials; i++)
                {
                    callSumDifference = callSumDifference + Math.Pow((pricesByTrial[0, i] - callPrice), 2);
                    putSumDifference = putSumDifference + Math.Pow((pricesByTrial[1, i] - putPrice), 2);
                }

                //standard deviation
                callStandardDeviation = Math.Sqrt(callSumDifference / (trials - 1));
                putStandardDeviation = Math.Sqrt(putSumDifference / (trials - 1));
                //standard error
                callStandardError = callStandardDeviation / (Math.Sqrt(trials));
                putStandardError = putStandardDeviation / (Math.Sqrt(trials));

                prices.Add("callStandardError", callStandardError);
                prices.Add("putStandardError", putStandardError);
            }
            catch (Exception ex)
            {

                log = ex.Message + " at GetPrices() for calculating variances.";
            }

            //The Variances/Standard Calculation does not need to be changed to handle antithetic logic.
            //pricesByTrial[] Implementaion; call/putSumDifference Implementation calculate Variances using Iteration and Summation.
            //This Implementation happen to work both for calculating Variances for single Random Variable, and Antithetic Corr. Random Variables.
            //See PDF Documentation on correlated path in the resources for mathematical proofs. 
            #endregion

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
            table.Rows.Add("Standard Error", null, null);

            return table;
        }

        public static DataTable GetDataTable(int steps, int trials, double s, double k, double t, double sig, double r, double estimateLevel = 0.01)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DataTable table = new DataTable();
            table.Columns.Add("Parameters", typeof(string));
            table.Columns.Add("Call", typeof(double));
            table.Columns.Add("Put", typeof(double));

            double sHigh = s * (1 + estimateLevel), sLow = s * (1 - estimateLevel);
            double tHigh = t * (1 + estimateLevel);
            
            double rHigh = r * (1 + estimateLevel), rLow = r * (1 - estimateLevel);
            double sigHigh = sig * (1 + estimateLevel), sighLow = sig * (1 - estimateLevel);

            #region Price
            Dictionary<string, double> prices = GetPrices(steps, trials, s, k, t, sig, r);
            double callPrice = Math.Round(prices["call"], 3);
            double putPrice = Math.Round(prices["put"], 3);
            #endregion

            #region StandardError
            double callStandardError = Math.Round(prices["callStandardError"], 3);
            double putStandardError = Math.Round(prices["putStandardError"], 3);
            #endregion

            #region Delta 
            Dictionary<string, double> highUnderlytingPrices = GetPrices(steps, trials, sHigh, k, t, sig, r);
            double highUnderlyingCallPrice = highUnderlytingPrices["call"], highUnderlyingPutPrice = highUnderlytingPrices["put"];

            Dictionary<string, double> lowUnderlyingPrices = GetPrices(steps, trials, sLow, k, t, sig, r);
            double lowUnderlyingCallPrice = lowUnderlyingPrices["call"], lowUnderlyingPutPrice = lowUnderlyingPrices["put"];

            //Formula to Calculate Delta referenced from class notes: dC/dS
            double callDelta = Math.Round((highUnderlyingCallPrice - callPrice) / (estimateLevel * s), 3);
            double putDelta = Math.Round((highUnderlyingPutPrice - putPrice) / (estimateLevel * s), 3);
            #endregion

            #region Gamma 
            //Formula to Calculate Gamma referencing class notes: d^2C/dS^2
            double callGamma = Math.Round((highUnderlyingCallPrice - 2 * callPrice + lowUnderlyingCallPrice) / (Math.Pow(estimateLevel * s, 2)), 3);
            double putGamma = Math.Round((highUnderlyingPutPrice - 2 * putPrice + lowUnderlyingPutPrice) / (Math.Pow(estimateLevel * s, 2)), 3);
            #endregion  

            #region Theta
            Dictionary<string, double> highTPrices = GetPrices(steps, trials, s, k, tHigh, sig, r);
            double highTCallPrice = highTPrices["call"], highTPutPrice = highTPrices["put"];

            //Formula to calculate Theta referencing class notes: dC/dt
            double callTheta = Math.Round(-(highTCallPrice - callPrice) / (estimateLevel * t), 3);
            double putTheta = Math.Round(-(highTPutPrice - putPrice) / (estimateLevel * t), 3);
            #endregion

            #region Rho        
            Dictionary<string, double> highRPrices = GetPrices(steps, trials, s, k, t, sig, rHigh);
            double highRCallPrice = highRPrices["call"], highRPutPrice = highRPrices["put"];

            Dictionary<string, double> lowRPrices = GetPrices(steps, trials, s, k, t, sig, rLow);
            double lowRCallPrice = lowRPrices["call"], lowRPutPrice = lowRPrices["put"];

            //Formula to calculate Rho: dC/dr
            double callRho = Math.Round((highRCallPrice - lowRCallPrice) / (2 * estimateLevel * r), 3);
            double putRho = Math.Round((highRPutPrice - lowRPutPrice) / (2 * estimateLevel * r), 3);
            #endregion

            #region Vega           
            Dictionary<string, double> highSigPrices = GetPrices(steps, trials, s, k, t, sigHigh, r);
            double highSigCallPrice = highSigPrices["call"], highSigPutPrice = highSigPrices["put"];

            Dictionary<string, double> lowSigPrices = GetPrices(steps, trials, s, k, t, sighLow, r);
            double lowSigCallPrice = lowSigPrices["call"], lowSigPutPrice = lowSigPrices["put"];

            //Formula to calcualte Vega: dC/dsig
            double callVega = Math.Round((highSigCallPrice - lowSigCallPrice) / (2 * estimateLevel * sig), 3);
            double putVega = Math.Round((highSigPutPrice - lowSigPutPrice) / (2 * estimateLevel * sig), 3);
            #endregion


            table.Rows.Add("Thoretical Price", callPrice, putPrice);
            table.Rows.Add("Delta", callDelta, putDelta);
            table.Rows.Add("Gamma", callGamma, putGamma);
            table.Rows.Add("Theta", callTheta, putTheta);
            table.Rows.Add("Rho", callRho, putRho);
            table.Rows.Add("Vega", callVega, putVega);
            table.Rows.Add("Standard Error", callStandardError, putStandardError);

            //reset RandomNumbers after each Pricing Request
            RandomNumbers = null;

            //reset Variance/Algo Speed Option after each pricing request
            //Antithetic = false;
            foreach (var key in VaraianceReductionOptions.Keys.ToList())
            {
                VaraianceReductionOptions[key] = false;
            }

            stopwatch.Stop();
            AlgoTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
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
