using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eagle.Business_Logic
{
    public class BarrierOption
    {
        private static double[,] RandomNumbers;
        public static double AlgoTime;

        //Set VarianceReduction Option
        public static Dictionary<string, bool> VaraianceReductionOptions = new Dictionary<string, bool>()
        {
            {"Antithetic_Variance_Reduction", false },
            {"Control_Variate", false },
            {"Multithread_Parallel_Compute",false }
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

                #region Sequential For Loop
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
                #endregion
              
            }
            catch (Exception ex)
            {

                log = ex.Message + " at GenerateRandomNumbers()";
            }

            RandomNumbers = matrix;
        }

        #region Monte Carlo Simulation

        //Algo to Generate Simulation using M.C Method      
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
            var multiThreading = VaraianceReductionOptions["Multithread_Parallel_Compute"];

            if (RandomNumbers == null)
            {
                GenerateRandomNumbers(trials, steps);
            }

            try
            {
                //Formula to genearte simulation using antithetic method referenced from lecture notes

                //Sequential For Loop
                if (!multiThreading)
                {
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


                            //regular
                            simulationRegular[i, j] = simulationRegular[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                                sig * Math.Sqrt(timeIncrement) * RandomNumbers[i, j - 1]);

                            //antithetic not control variate 
                            if (antithetic && !controlVariate)
                            {
                                simulationAtithetic[i, j] = simulationAtithetic[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                                sig * Math.Sqrt(timeIncrement) * (-1) * RandomNumbers[i, j - 1]);
                            }

                            //control variate but not antithetic
                            if (controlVariate && !antithetic)
                            {
                                tHedge = (i - 1) * timeIncrement;
                                deltaCall = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                                deltaPut = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];

                                controlVariatePathCall[i, j] = controlVariatePathCall[i, j - 1] + deltaCall *
                                    (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathPut[i, j] = controlVariatePathPut[i, j - 1] + deltaPut *
                                    (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                            }

                            //control variate and antithetic
                            if (antithetic && controlVariate)
                            {
                                tHedge = (i - 1) * timeIncrement;
                                deltaCall = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                                deltaPut = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];

                                //antithetic simulation
                                simulationAtithetic[i, j] = simulationAtithetic[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                                sig * Math.Sqrt(timeIncrement) * (-1) * RandomNumbers[i, j - 1]);

                                //control variate regular 
                                controlVariatePathCall[i, j] = controlVariatePathCall[i, j - 1] + deltaCall *
                                   (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathPut[i, j] = controlVariatePathPut[i, j - 1] + deltaPut *
                                    (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));

                                //control variate antithetic
                                controlVariatePathAntiTheticCall[i, j] = controlVariatePathAntiTheticCall[i, j - 1] + deltaCall *
                                    (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathAntiTheticPut[i, j] = controlVariatePathAntiTheticPut[i, j - 1] + deltaPut *
                                    (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
                            }
                        }

                    }
                }

                //Parallel For Loop saves half time in all computations
                else
                {
                    Parallel.For(0, trials, i =>
                    {
                        simulationRegular[i, 0] = s;
                        simulationAtithetic[i, 0] = s;
                        controlVariatePathCall[i, 0] = 0;
                        controlVariatePathPut[i, 0] = 0;
                        controlVariatePathAntiTheticCall[i, 0] = 0;
                        controlVariatePathAntiTheticPut[i, 0] = 0;

                        for (int j = 1; j < steps; j++)
                        {
                            //regular
                            simulationRegular[i, j] = simulationRegular[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                               sig * Math.Sqrt(timeIncrement) * RandomNumbers[i, j - 1]);

                            //antithetic not control variate 
                            if (antithetic && !controlVariate)
                            {
                                simulationAtithetic[i, j] = simulationAtithetic[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                                sig * Math.Sqrt(timeIncrement) * (-1) * RandomNumbers[i, j - 1]);
                            }

                            //control variate but not antithetic
                            if (controlVariate && !antithetic)
                            {
                                tHedge = (i - 1) * timeIncrement;
                                deltaCall = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                                deltaPut = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];

                                controlVariatePathCall[i, j] = controlVariatePathCall[i, j - 1] + deltaCall *
                                    (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathPut[i, j] = controlVariatePathPut[i, j - 1] + deltaPut *
                                    (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                            }

                            //control variate and antithetic
                            if (antithetic && controlVariate)
                            {
                                tHedge = (i - 1) * timeIncrement;
                                deltaCall = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];
                                deltaPut = BlackScholesDeltas(s, k, t, tHedge, sig, r)["deltaCall"];

                                //antithetic simulation
                                simulationAtithetic[i, j] = simulationAtithetic[i, j - 1] * Math.Exp(((r - Math.Pow(sig, 2) / 2)) * timeIncrement +
                               sig * Math.Sqrt(timeIncrement) * (-1) * RandomNumbers[i, j - 1]);

                                //control variate regular 
                                controlVariatePathCall[i, j] = controlVariatePathCall[i, j - 1] + deltaCall *
                                  (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathPut[i, j] = controlVariatePathPut[i, j - 1] + deltaPut *
                                    (simulationRegular[i, j] - simulationRegular[i, j - 1] * Math.Exp(r * timeIncrement));

                                //control variate antithetic
                                controlVariatePathAntiTheticCall[i, j] = controlVariatePathAntiTheticCall[i, j - 1] + deltaCall *
                                   (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
                                controlVariatePathAntiTheticPut[i, j] = controlVariatePathAntiTheticPut[i, j - 1] + deltaPut *
                                    (simulationAtithetic[i, j] - simulationAtithetic[i, j - 1] * Math.Exp(r * timeIncrement));
                            }
                        }

                    });
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
        public static Dictionary<string, double> GetPrices(int steps, int trials, double s, double k, double t, double sig, double r, double barrier)
        {
            #region Prices
            Dictionary<string, double> prices = new Dictionary<string, double>();
            double total_Call_Price_Up_In = 0, total_Put_Price_Up_In = 0, call_Price_Up_In = 0, put_Price_Up_In = 0;
            double total_Call_Price_Up_Out = 0, total_Put_Price_Up_Out = 0, call_Price_Up_Out = 0, put_Price_Up_Out = 0;
            double total_Call_Price_Down_In = 0, total_Put_Price_Down_In = 0, call_Price_Down_In = 0, put_Price_Down_In = 0;
            double total_Call_Price_Down_Out = 0, total_Put_Price_Down_Out = 0, call_Price_Down_Out = 0, put_Price_Down_Out = 0;

            double[,] pricesByTrial = new double[8, trials];
            var antithetic = VaraianceReductionOptions["Antithetic_Variance_Reduction"];
            var controlVariate = VaraianceReductionOptions["Control_Variate"];

            var simulations = GenerateSimulations(steps, trials, s, k, t, sig, r);
            var simulationRegular = simulations["regular"];
            var simulationAntithetic = simulations["antithetic"];
            var controlVariatePathCall = simulations["controlVariatePathCall"];
            var controlVariatePathPut = simulations["controlVariatePathPut"];
            var controlVariatePathAntiTheticCall = simulations["controlVariatePathAntiTheticCall"];
            var controlVariatePathAntiTheticPut = simulations["controlVariatePathAntiTheticPut"];

            double[] up_In = new double[trials], up_Out = new double[trials], down_In = new double[trials], down_Out = new double[trials];
            double[] up_In_Antithetic = new double[trials], up_Out_Antithetic = new double[trials], 
                down_In_Antithetic = new double[trials], down_Out_Antithetic = new double[trials];

            try
            {
                if (!antithetic)
                {
                    //Formulat to Calculate Call/ Put Price referenced from Lecture Notes
                    for (int i = 0; i < trials; i++)
                    {
                        for (int j = 0; j < steps; j++)
                        {
                            //upIN
                            if (simulationRegular[i, j] >= barrier)
                                up_In[i] = simulationRegular[i, steps - 1];
                            else
                                up_In[i] = 0;

                            //upOut
                            if (simulationRegular[i, j] > barrier)
                                up_Out[i] = 0;                            
                            else
                                up_Out[i] = simulationRegular[i, steps - 1];

                            //DownIn
                            if (simulationRegular[i, j] <= barrier)
                                down_In[i] = simulationRegular[i, steps - 1];
                            else
                                down_In[i] = 0;

                            //DownOut
                            if (simulationRegular[i, j] < barrier)
                                down_Out[i] = 0;
                            else
                                down_Out[i] = simulationRegular[i, steps - 1];


                        }

                        if (controlVariate)
                        {
                            //control variate price
                            //upIn
                            pricesByTrial[0, i] = Math.Max(up_In[i] - k, 0) - controlVariatePathCall[i, steps - 1];
                            pricesByTrial[1, i] = Math.Max(k - up_In[i], 0) - controlVariatePathPut[i, steps - 1];

                            //upOut
                            pricesByTrial[2, i] = Math.Max(up_Out[i] - k, 0) - controlVariatePathCall[i, steps - 1];
                            pricesByTrial[3, i] = Math.Max(k - up_Out[i], 0) - controlVariatePathPut[i, steps - 1];

                            //downIn
                            pricesByTrial[4, i] = Math.Max(down_In[i] - k, 0) - controlVariatePathCall[i, steps - 1];
                            pricesByTrial[5, i] = Math.Max(k - down_In[i], 0) - controlVariatePathPut[i, steps - 1];

                            //downOut
                            pricesByTrial[6, i] = Math.Max(down_Out[i] - k, 0) - controlVariatePathCall[i, steps - 1];
                            pricesByTrial[7, i] = Math.Max(k - down_Out[i], 0) - controlVariatePathPut[i, steps - 1];
                        }
                        else
                        {
                            //regular price
                            //upIN
                            pricesByTrial[0, i] = Math.Max(up_In[i] - k, 0);
                            pricesByTrial[1, i] = Math.Max(k - up_In[i], 0);

                            //upOut
                            pricesByTrial[2, i] = Math.Max(up_Out[i] - k, 0);
                            pricesByTrial[3, i] = Math.Max(k - up_Out[i], 0);

                            //downIn
                            pricesByTrial[4, i] = Math.Max(down_In[i] - k, 0);
                            pricesByTrial[5, i] = Math.Max(k - down_In[i], 0);

                            //downOut
                            pricesByTrial[6, i] = Math.Max(down_Out[i] - k, 0);
                            pricesByTrial[7, i] = Math.Max(k - down_Out[i], 0);
                        }

                        //upIn
                        total_Call_Price_Up_In = total_Call_Price_Up_In + pricesByTrial[0, i];
                        total_Put_Price_Up_In = total_Put_Price_Up_In + pricesByTrial[1, i];

                        //upOut
                        total_Call_Price_Up_Out = total_Call_Price_Up_Out + pricesByTrial[2, i];
                        total_Put_Price_Up_Out = total_Put_Price_Up_Out + pricesByTrial[3, i];

                        //downIn
                        total_Call_Price_Down_In = total_Call_Price_Down_In + pricesByTrial[4, i];
                        total_Put_Price_Down_In = total_Put_Price_Down_In + pricesByTrial[5, i];

                        //downOut
                        total_Call_Price_Down_Out = total_Call_Price_Down_Out + pricesByTrial[6, i];
                        total_Put_Price_Down_Out = total_Put_Price_Down_Out + pricesByTrial[7, i];
                    }
                }
                else
                {
                    for (int i = 0; i < trials; i++)
                    {
                        for (int j = 0; j < steps; j++)
                        {         
                            //UpIn
                            if (simulationRegular[i, j] >= barrier)
                                up_In[i] = simulationRegular[i, steps - 1];
                            else
                                up_In[i] = 0;

                            if (simulationAntithetic[i, j] >= barrier)
                                up_In_Antithetic[i] = simulationAntithetic[i, steps - 1];
                            else
                                up_In_Antithetic[i] = 0;

                            //UpOut
                            if (simulationRegular[i, j] > barrier)
                                up_Out[i] = 0;
                            else
                                up_Out[i] = simulationRegular[i, steps - 1];

                            if (simulationAntithetic[i, j] > barrier)
                                up_Out_Antithetic[i] = 0;
                            else
                                up_Out_Antithetic[i] = simulationRegular[i, steps - 1];

                            //downIn
                            if (simulationRegular[i, j] <= barrier)
                                down_In[i] = simulationRegular[i, steps - 1];
                            else
                                down_In[i] = 0;

                            if (simulationAntithetic[i, j] <= barrier)
                                down_In_Antithetic[i] = simulationAntithetic[i, steps - 1];
                            else
                                down_In_Antithetic[i] = 0;

                            //downOut
                            if (simulationRegular[i, j] < barrier)
                                down_Out[i] = 0;
                            else
                                down_Out[i] = simulationRegular[i, steps - 1];

                            if (simulationAntithetic[i, j] < barrier)
                                down_Out_Antithetic[i] = 0;
                            else
                                down_Out_Antithetic[i] = simulationAntithetic[i, steps - 1];
                        }

                        if (controlVariate)
                        {
                            //antithetic and control variate price
                            //upIn
                            pricesByTrial[0, i] = 0.5 * (Math.Max(up_In[i] - k, 0) - controlVariatePathCall[i, steps - 1]
                                + Math.Max(up_In_Antithetic[i] - k, 0) - controlVariatePathAntiTheticCall[i, steps - 1]);

                            pricesByTrial[1, i] = 0.5 * (Math.Max(k - up_In[i], 0) - controlVariatePathPut[i, steps - 1]
                                + Math.Max(k - up_In_Antithetic[i], 0) - controlVariatePathAntiTheticPut[i, steps - 1]);

                            //upOut
                            pricesByTrial[2, i] = 0.5 * (Math.Max(up_Out[i] - k, 0) - controlVariatePathCall[i, steps - 1]
                                + Math.Max(up_Out_Antithetic[i] - k, 0) - controlVariatePathAntiTheticCall[i, steps - 1]);

                            pricesByTrial[3, i] = 0.5 * (Math.Max(k - up_Out[i], 0) - controlVariatePathPut[i, steps - 1]
                                + Math.Max(k - up_Out_Antithetic[i], 0) - controlVariatePathAntiTheticPut[i, steps - 1]);

                            //downIn
                            pricesByTrial[4, i] = 0.5 * (Math.Max(down_In[i] - k, 0) - controlVariatePathCall[i, steps - 1]
                                + Math.Max(down_In_Antithetic[i] - k, 0) - controlVariatePathAntiTheticCall[i, steps - 1]);

                            pricesByTrial[5, i] = 0.5 * (Math.Max(k - down_In[i], 0) - controlVariatePathPut[i, steps - 1]
                               + Math.Max(k - down_In_Antithetic[i], 0) - controlVariatePathAntiTheticPut[i, steps - 1]);

                            //downOut
                            pricesByTrial[6, i] = 0.5 * (Math.Max(down_Out[i] - k, 0) - controlVariatePathCall[i, steps - 1]
                                + Math.Max(down_Out_Antithetic[i] - k, 0) - controlVariatePathAntiTheticCall[i, steps - 1]);

                            pricesByTrial[7, i] = 0.5 * (Math.Max(k - down_Out[i], 0) - controlVariatePathPut[i, steps - 1]
                                + Math.Max(k - down_Out_Antithetic[i], 0) - controlVariatePathAntiTheticPut[i, steps - 1]);
                        }
                        else
                        {
                            //antithetic price
                            //upIn
                            pricesByTrial[0, i] = 0.5 * (Math.Max(up_In[i] - k, 0) +
                            Math.Max(up_In_Antithetic[i] - k, 0));

                            pricesByTrial[1, i] = 0.5 * (Math.Max(k - up_In[i], 0) +
                                Math.Max(k - up_In_Antithetic[i], 0));

                            //upOut
                            pricesByTrial[2, i] = 0.5 * (Math.Max(up_Out[i] - k, 0) +
                            Math.Max(up_Out_Antithetic[i] - k, 0));

                            pricesByTrial[3, i] = 0.5 * (Math.Max(k - up_Out[i], 0) +
                                Math.Max(k - up_Out_Antithetic[i], 0));

                            //downIn
                            pricesByTrial[4, i] = 0.5 * (Math.Max(down_In[i] - k, 0) +
                            Math.Max(down_In_Antithetic[i] - k, 0));

                            pricesByTrial[5, i] = 0.5 * (Math.Max(k - down_In[i], 0) +
                                Math.Max(k - down_In_Antithetic[i], 0));

                            //downOut
                            pricesByTrial[6, i] = 0.5 * (Math.Max(down_Out[i] - k, 0) +
                            Math.Max(down_Out_Antithetic[i] - k, 0));

                            pricesByTrial[7, i] = 0.5 * (Math.Max(k - down_Out[i], 0) +
                                Math.Max(k - down_Out_Antithetic[i], 0));

                        }

                        //upIn
                        total_Call_Price_Up_In = total_Call_Price_Up_In + pricesByTrial[0, i];
                        total_Put_Price_Up_In = total_Put_Price_Up_In + pricesByTrial[1, i];

                        //upOut
                        total_Call_Price_Up_Out = total_Call_Price_Up_Out + pricesByTrial[2, i];
                        total_Put_Price_Up_Out = total_Put_Price_Up_Out + pricesByTrial[3, i];

                        //downIn
                        total_Call_Price_Down_In = total_Call_Price_Down_In + pricesByTrial[4, i];
                        total_Put_Price_Down_In = total_Put_Price_Down_In + pricesByTrial[5, i];

                        //downOut
                        total_Call_Price_Down_Out = total_Call_Price_Down_Out + pricesByTrial[6, i];
                        total_Put_Price_Down_Out = total_Put_Price_Down_Out + pricesByTrial[7, i];
                    }
                }

                //Formula to Calcualte Simulation Option Price referenced from Lecture Notes: SUM/Trials * Discount_Factor
                //upIn
                call_Price_Up_In = total_Call_Price_Up_In / trials * Math.Exp(-r * t);
                put_Price_Up_In = total_Put_Price_Up_In / trials * Math.Exp(-r * t);

                //upOut
                call_Price_Up_Out = total_Call_Price_Up_Out / trials * Math.Exp(-r * t); 
                put_Price_Up_Out = total_Put_Price_Up_Out / trials * Math.Exp(-r * t);

                //downIn
                call_Price_Down_In = total_Call_Price_Down_In / trials * Math.Exp(-r * t);
                put_Price_Down_In = total_Put_Price_Down_In / trials * Math.Exp(-r * t);

                //downOut
                call_Price_Down_Out = total_Call_Price_Down_Out / trials * Math.Exp(-r * t);
                put_Price_Down_Out = total_Put_Price_Down_Out / trials * Math.Exp(-r * t);

                prices.Add("call_Up_In", call_Price_Up_In);
                prices.Add("put_Up_In", put_Price_Up_In);
                prices.Add("call_Up_Out", call_Price_Up_Out);
                prices.Add("put_Up_Out", put_Price_Up_Out);
                prices.Add("call_Down_In", call_Price_Down_In);
                prices.Add("put_Down_In", put_Price_Down_In);
                prices.Add("call_Down_Out", call_Price_Down_Out);
                prices.Add("put_Down_Out", put_Price_Down_Out);
            }
            catch (Exception ex)
            {

                log = ex.Message + "at GetPrices() for calcualting prices.";
            }

            #endregion

            #region Variance/Standard Error
            //upIn
            double call_Up_In_SumDifference = 0, put_Up_In_SumDifference = 0;
            double call_Up_In_StandardDeviation, put_Up_In_StandardDeviation;
            double call_Up_In_StandardError, put_Up_In_StandardError;

            //upOut
            double call_Up_Out_SumDifference = 0, put_Up_Out_SumDifference = 0;
            double call_Up_Out_StandardDeviation, put_Up_Out_StandardDeviation;
            double call_Up_Out_StandardError, put_Up_Out_StandardError;

            //downIn
            double call_Down_In_SumDifference = 0, put_Down_In_SumDifference = 0;
            double call_Down_In_StandardDeviation, put_Down_In_StandardDeviation;
            double call_Down_In_StandardError, put_Down_In_StandardError;

            //downOut
            double call_Down_Out_SumDifference = 0, put_Down_Out_SumDifference = 0;
            double call_Down_Out_StandardDeviation, put_Down_Out_StandardDeviation;
            double call_Down_Out_StandardError, put_Down_Out_StandardError;

            try
            {
                //Formula to Calcualte StandardDeviation, StandardError from class notes: SD = Sqrt(1/(m-1) * Sum(C(0,j) - C0)^2) SE = SD/Sqrt(m)
                for (int i = 0; i < trials; i++)
                {
                    //UpIn
                    call_Up_In_SumDifference = call_Up_In_SumDifference + Math.Pow((pricesByTrial[0, i] - call_Price_Up_In), 2);
                    put_Up_In_SumDifference = put_Up_In_SumDifference + Math.Pow((pricesByTrial[1, i] - put_Price_Up_In), 2);

                    //UpOut
                    call_Up_Out_SumDifference = call_Up_Out_SumDifference + Math.Pow((pricesByTrial[2, i] - call_Price_Up_Out), 2);
                    put_Up_Out_SumDifference = put_Up_Out_SumDifference + Math.Pow((pricesByTrial[3, i] - put_Price_Up_Out), 2);

                    //downIn
                    call_Down_In_SumDifference = call_Down_In_SumDifference + Math.Pow((pricesByTrial[4, i] - call_Price_Down_In), 2);
                    put_Down_In_SumDifference = put_Down_In_SumDifference + Math.Pow((pricesByTrial[5, i] - put_Price_Down_In), 2);

                    //downOut
                    call_Down_Out_SumDifference = call_Down_Out_SumDifference + Math.Pow((pricesByTrial[6, i] - call_Price_Down_Out), 2);
                    put_Down_Out_SumDifference = put_Down_Out_SumDifference + Math.Pow((pricesByTrial[7, i] - put_Price_Down_Out), 2);

                }

                //standard deviation
                //upIn
                call_Up_In_StandardDeviation = Math.Sqrt(call_Up_In_SumDifference / (trials - 1));
                put_Up_In_StandardDeviation = Math.Sqrt(put_Up_In_SumDifference / (trials - 1));

                //upOut
                call_Up_Out_StandardDeviation = Math.Sqrt(call_Up_Out_SumDifference / (trials - 1));
                put_Up_Out_StandardDeviation = Math.Sqrt(put_Up_Out_SumDifference / (trials - 1));

                //downIn
                call_Down_In_StandardDeviation = Math.Sqrt(call_Down_In_SumDifference / (trials - 1));
                put_Down_In_StandardDeviation = Math.Sqrt(put_Down_In_SumDifference / (trials - 1));

                //downOut
                call_Down_Out_StandardDeviation = Math.Sqrt(call_Down_Out_SumDifference / (trials - 1));
                put_Down_Out_StandardDeviation = Math.Sqrt(put_Down_Out_SumDifference / (trials - 1));


                //standard error
                //upIn
                call_Up_In_StandardError = call_Up_In_StandardDeviation / (Math.Sqrt(trials));
                put_Up_In_StandardError = put_Up_In_StandardDeviation / (Math.Sqrt(trials));

                //upOut
                call_Up_Out_StandardError = call_Up_Out_StandardDeviation / (Math.Sqrt(trials));
                put_Up_Out_StandardError = put_Up_Out_StandardDeviation / (Math.Sqrt(trials));

                //downIn
                call_Down_In_StandardError = call_Down_In_StandardDeviation / (Math.Sqrt(trials));
                put_Down_In_StandardError = put_Down_In_StandardDeviation / (Math.Sqrt(trials));

                //downOut
                call_Down_Out_StandardError = call_Down_Out_StandardDeviation / (Math.Sqrt(trials));
                put_Down_Out_StandardError = put_Down_Out_StandardDeviation / (Math.Sqrt(trials));

                prices.Add("call_Up_In_StandardError", call_Up_In_StandardError);
                prices.Add("put_Up_In_StandardError", put_Up_In_StandardError);
                prices.Add("call_Up_Out_StandardError", call_Up_Out_StandardError);
                prices.Add("put_Up_Out_StandardError", put_Up_Out_StandardError);
                prices.Add("call_Down_In_StandardError", call_Down_In_StandardError);
                prices.Add("put_Down_In_StandardError", put_Down_In_StandardError);
                prices.Add("call_Down_Out_StandardError", call_Down_Out_StandardError);
                prices.Add("put_Down_Out_StandardError", put_Down_Out_StandardError);
            }
            catch (Exception ex)
            {

                log = ex.Message + " at GetPrices() for calculating variances.";
            }
            
            #endregion

            return prices;
        }

        public static DataTable SetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Parameters", typeof(string));
            table.Columns.Add("UP & In Call", typeof(double));
            table.Columns.Add("Up & In Put", typeof(double));
            table.Columns.Add("Up & Out Call", typeof(double));
            table.Columns.Add("Up & Out Put", typeof(double));
            table.Columns.Add("Down & In Call", typeof(double));
            table.Columns.Add("Down & In Put", typeof(double));
            table.Columns.Add("Down & Out Call", typeof(double));
            table.Columns.Add("Down & Out Put", typeof(double));

            table.Rows.Add("Thoretical Price", null, null, null, null, null, null, null);
            table.Rows.Add("Delta", null, null, null, null, null, null, null);
            table.Rows.Add("Gamma", null, null, null, null, null, null, null);
            table.Rows.Add("Theta", null, null, null, null, null, null, null);
            table.Rows.Add("Rho", null, null, null, null, null, null, null);
            table.Rows.Add("Vega", null, null, null, null, null, null, null);
            table.Rows.Add("Standard Error", null, null, null, null, null, null, null);

            return table;
        }

        public static DataSet GetDataSet(int steps, int trials, double s, double k, double t, double sig, double r, double barrier, double estimateLevel = 0.01)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DataSet dataSet = new DataSet("dataSet");
            DataTable table1 = dataSet.Tables.Add();
            DataTable timerTable = dataSet.Tables.Add();


            #region DataTable

            table1.Columns.Add("Parameters", typeof(string));
            table1.Columns.Add("UP & In Call", typeof(double));
            table1.Columns.Add("Up & In Put", typeof(double));
            table1.Columns.Add("Up & Out Call", typeof(double));
            table1.Columns.Add("Up & Out Put", typeof(double));
            table1.Columns.Add("Down & In Call", typeof(double));
            table1.Columns.Add("Down & In Put", typeof(double));
            table1.Columns.Add("Down & Out Call", typeof(double));
            table1.Columns.Add("Down & Out Put", typeof(double));


            double sHigh = s * (1 + estimateLevel), sLow = s * (1 - estimateLevel);
            double tHigh = t * (1 + estimateLevel);

            double rHigh = r * (1 + estimateLevel), rLow = r * (1 - estimateLevel);
            double sigHigh = sig * (1 + estimateLevel), sighLow = sig * (1 - estimateLevel);            

            #region Price
            Dictionary<string, double> prices = GetPrices(steps, trials, s, k, t, sig, r, barrier);
            double call_Up_In_Price = Math.Round(prices["call_Up_In"], 3), put_Up_In_Price = Math.Round(prices["put_Up_In"], 3);
            double call_Up_Out_Price = Math.Round(prices["call_Up_Out"], 3), put_Up_Out_Price = Math.Round(prices["put_Up_Out"], 3);
            double call_Down_In_Price = Math.Round(prices["call_Down_In"], 3), put_Down_In_Price = Math.Round(prices["put_Down_In"], 3);
            double call_Down_Out_Price = Math.Round(prices["call_Down_Out"], 3), put_Down_Out_Price = Math.Round(prices["put_Down_Out"], 3);
            #endregion
        
            #region StandardError
            double call_Up_In_StandardError = Math.Round(prices["call_Up_In_StandardError"], 3), 
                put_Up_In_StandardError = Math.Round(prices["put_Up_In_StandardError"], 3);
            double call_Up_Out_StandardError = Math.Round(prices["call_Up_Out_StandardError"], 3), 
                put_Up_Out_StandardError = Math.Round(prices["put_Up_Out_StandardError"], 3);
            double call_Down_In_StandardError = Math.Round(prices["call_Down_In_StandardError"], 3), 
                put_Down_In_StandardError = Math.Round(prices["put_Down_In_StandardError"], 3);
            double call_Down_Out_StandardError = Math.Round(prices["call_Down_Out_StandardError"], 3), 
                put_Down_Out_StandardError = Math.Round(prices["put_Down_Out_StandardError"], 3);
            #endregion

            #region Delta 
            Dictionary<string, double> highUnderlytingPrices = GetPrices(steps, trials, sHigh, k, t, sig, r, barrier);
            double high_Underlying__Price_Call_Up_In = highUnderlytingPrices["call_Up_In"],
                high_Underlying__Price_Put_Up_In = highUnderlytingPrices["put_Up_In"];
            double high_Underlying_Price_Call_Up_Out = highUnderlytingPrices["call_Up_Out"],
                high_Underlying_Price_Put_Up_Out = highUnderlytingPrices["put_Up_Out"];
            double high_Underlying_Price_Call_Down_In = highUnderlytingPrices["call_Down_In"],
                high_Underlying_Price_Put_Down_In = highUnderlytingPrices["put_Down_In"];
            double high_Underlying_Price_Call_Down_Out = highUnderlytingPrices["call_Down_Out"],
                high_Underlying_Price_Put_Down_Out = highUnderlytingPrices["put_Down_Out"];


            Dictionary<string, double> lowUnderlyingPrices = GetPrices(steps, trials, sLow, k, t, sig, r, barrier);
            double low_Underlying_Price_Call_Up_In = lowUnderlyingPrices["call_Up_In"],
                low_Underlying_Price_Put_Up_In = lowUnderlyingPrices["put_Up_In"];
            double low_Underlying_Price_Call_Up_Out = lowUnderlyingPrices["call_Up_Out"],
                low_Underlying_Price_Put_Up_Out = lowUnderlyingPrices["put_Up_Out"];
            double low_Underlying_Price_Call_Down_In = lowUnderlyingPrices["call_Down_In"],
                low_Underlying_Price_Put_Down_In = lowUnderlyingPrices["put_Down_In"];
            double low_Underlying_Price_Call_Down_Out = lowUnderlyingPrices["call_Down_Out"],
                low_Underlying_Price_Put_Down_Out = lowUnderlyingPrices["put_Down_Out"];

            //Formula to Calculate Delta referenced from class notes: dC/dS
            double callUpInDelta = Math.Round((high_Underlying__Price_Call_Up_In - call_Up_In_Price) / (estimateLevel * s), 3), 
                putUpInDelta = Math.Round((high_Underlying__Price_Call_Up_In - put_Up_In_Price) / (estimateLevel * s), 3);
            double callUpOutDelta = Math.Round((high_Underlying_Price_Call_Up_Out - call_Up_Out_Price) / (estimateLevel * s), 3), 
                putUpOutDelta = Math.Round((high_Underlying_Price_Call_Up_Out - put_Up_Out_Price) / (estimateLevel * s), 3);
            double callDownInDelta = Math.Round((high_Underlying_Price_Call_Down_In - call_Down_In_Price) / (estimateLevel * s), 3), 
                putDownInDelta = Math.Round((high_Underlying_Price_Call_Down_In - put_Down_In_Price) / (estimateLevel * s), 3);
            double callDownOutDelta = Math.Round((high_Underlying_Price_Call_Down_Out - call_Down_Out_Price) / (estimateLevel * s), 3), 
                putDownOutDelta = Math.Round((high_Underlying_Price_Call_Down_Out - put_Down_Out_Price) / (estimateLevel * s), 3);
            #endregion

            #region Gamma 
            //Formula to Calculate Gamma referencing class notes: d^2C/dS^2
            double callUpInGamma = Math.Round((high_Underlying__Price_Call_Up_In - 2 * call_Up_In_Price + low_Underlying_Price_Call_Up_In) 
                / (Math.Pow(estimateLevel * s, 2)), 3), 
                putUpInGamma = Math.Round((high_Underlying_Price_Put_Up_Out - 2 * put_Up_In_Price + low_Underlying_Price_Put_Up_In) 
                / (Math.Pow(estimateLevel * s, 2)), 3);
            double callUpOutGamma = Math.Round((high_Underlying_Price_Call_Up_Out - 2 * call_Up_Out_Price + low_Underlying_Price_Call_Up_Out) 
                / (Math.Pow(estimateLevel * s, 2)), 3),
                putUpOutGamma = Math.Round((high_Underlying_Price_Put_Up_Out - 2 * put_Up_Out_Price + low_Underlying_Price_Put_Up_Out) 
                / (Math.Pow(estimateLevel * s, 2)), 3);
            double callDownInGamma = Math.Round((high_Underlying_Price_Call_Down_In - 2 * call_Down_In_Price + low_Underlying_Price_Call_Down_In) 
                / (Math.Pow(estimateLevel * s, 2)), 3),
                putDownInGamma = Math.Round((high_Underlying_Price_Put_Down_In - 2 * put_Down_In_Price + low_Underlying_Price_Put_Down_In)
                / (Math.Pow(estimateLevel * s, 2)), 3);
            double callDownOutGamma = Math.Round((high_Underlying_Price_Call_Down_Out - 2 * call_Down_Out_Price + low_Underlying_Price_Call_Down_Out) 
                / (Math.Pow(estimateLevel * s, 2)), 3),
                putDownOutGamma = Math.Round((high_Underlying_Price_Put_Down_Out - 2 * put_Down_Out_Price + low_Underlying_Price_Put_Down_Out) 
                / (Math.Pow(estimateLevel * s, 2)), 3);
            #endregion  

            #region Theta
            Dictionary<string, double> highTPrices = GetPrices(steps, trials, s, k, tHigh, sig, r, barrier);
            double highTCallUpInPrice = highTPrices["call_Up_In"], highTPutUpInPrice = highTPrices["put_Up_In"];
            double highTCallUpOutPrice = highTPrices["call_Up_Out"], highTPutUpOutPrice = highTPrices["put_Up_Out"];
            double highTCallDownInPrice = highTPrices["call_Down_In"], highTPutDownInPrice = highTPrices["put_Down_In"];
            double highTCallDownOutPrice = highTPrices["call_Down_Out"], highTPutDownOutPrice = highTPrices["put_Down_Out"];

            //Formula to calculate Theta referencing class notes: dC/dt
            double callUpInTheta = Math.Round(-(highTCallUpInPrice - call_Up_In_Price) / (estimateLevel * t), 3), 
                putUpInTheta = Math.Round(-(highTCallUpInPrice - put_Up_In_Price) / (estimateLevel * t), 3);
            double callUpOutTheta = Math.Round(-(highTCallUpOutPrice - call_Up_Out_Price) / (estimateLevel * t), 3), 
                putUpOutTheta = Math.Round(-(highTCallUpOutPrice - put_Up_Out_Price) / (estimateLevel * t), 3);
            double callDownInTheta = Math.Round(-(highTCallDownInPrice - call_Down_In_Price) / (estimateLevel * t), 3), 
                putDownInTheta = Math.Round(-(highTCallDownInPrice - put_Down_In_Price) / (estimateLevel * t), 3);
            double callDownOutTheta = Math.Round(-(highTCallDownOutPrice - call_Down_Out_Price) / (estimateLevel * t), 3), 
                putDownOutTheta = Math.Round(-(highTCallDownOutPrice - put_Down_Out_Price) / (estimateLevel * t), 3);
            #endregion  
           
            #region Rho        
            Dictionary<string, double> highRPrices = GetPrices(steps, trials, s, k, t, sig, rHigh, barrier);
            double highRCallUpInPrice = highRPrices["call_Up_In"], highRPutUpInPrice = highRPrices["put_Up_In"];
            double highRCallUpOutPrice = highRPrices["call_Up_Out"], highRPutUpOutPrice = highRPrices["put_Up_Out"];
            double highRCallDownInPrice = highRPrices["call_Down_In"], highRPutDownInPrice = highRPrices["put_Down_In"];
            double highRCallDownOutPrice = highRPrices["call_Down_Out"], highRPutDownOutPrice = highRPrices["put_Down_Out"];

            Dictionary<string, double> lowRPrices = GetPrices(steps, trials, s, k, t, sig, rLow, barrier);
            double lowRCallUpInPrice = lowRPrices["call_Up_In"], lowRPutUpInPrice = lowRPrices["put_Up_In"];
            double lowRCallUpOutPrice = lowRPrices["call_Up_Out"], lowRPutUpOutPrice = lowRPrices["put_Up_Out"];
            double lowRCallDownInPrice = lowRPrices["call_Down_In"], lowRPutDownInPrice = lowRPrices["put_Down_In"];
            double lowRCallDownOutPrice = lowRPrices["call_Down_Out"], lowRPutDownOutPrice = lowRPrices["put_Down_Out"];

            //Formula to calculate Rho: dC/dr
            double callUpInRho = Math.Round((highRCallUpInPrice - lowRCallUpInPrice) / (2 * estimateLevel * r), 3), putUpInRho = Math.Round((highRPutUpInPrice - lowRPutUpInPrice) / (2 * estimateLevel * r), 3);
            double callUpOutRho = Math.Round((highRCallUpOutPrice - lowRCallUpOutPrice) / (2 * estimateLevel * r), 3), putUpOutRho = Math.Round((highRPutUpOutPrice - lowRPutUpOutPrice) / (2 * estimateLevel * r), 3);
            double callDownInRho = Math.Round((highRCallDownInPrice - lowRCallDownInPrice) / (2 * estimateLevel * r), 3), putDownInRho = Math.Round((highRPutDownInPrice - lowRPutDownInPrice) / (2 * estimateLevel * r), 3);
            double callDownOutRho = Math.Round((highRCallDownOutPrice - lowRCallDownOutPrice) / (2 * estimateLevel * r), 3), putDownOutRho = Math.Round((highRPutDownOutPrice - lowRPutDownOutPrice) / (2 * estimateLevel * r), 3);
            #endregion

            #region Vega           
            Dictionary<string, double> highSigPrices = GetPrices(steps, trials, s, k, t, sigHigh, r, barrier);
            double highSigCallUpInPrice = highSigPrices["call_Up_In"], highSigPutUpInPrice = highSigPrices["put_Up_In"];
            double highSigCallUpOutPrice = highSigPrices["call_Up_Out"], highSigPutUpOutPrice = highSigPrices["put_Up_Out"];
            double highSigCallDownInPrice = highSigPrices["call_Down_In"], highSigPutDownInPrice = highSigPrices["put_Down_In"];
            double highSigCallDownOutPrice = highSigPrices["call_Down_Out"], highSigPutDownOutPrice = highSigPrices["put_Down_Out"];

            Dictionary<string, double> lowSigPrices = GetPrices(steps, trials, s, k, t, sighLow, r, barrier);
            double lowSigCallUpInPrice = lowSigPrices["call_Up_In"], lowSigPutUpInPrice = lowSigPrices["put_Up_In"];
            double lowSigCallUpOutPrice = lowSigPrices["call_Up_Out"], lowSigPutUpOutPrice = lowSigPrices["put_Up_Out"];
            double lowSigCallDownInPrice = lowSigPrices["call_Down_In"], lowSigPutDownInPrice = lowSigPrices["put_Down_In"];
            double lowSigCallDownOutPrice = lowSigPrices["call_Down_Out"], lowSigPutDownOutPrice = lowSigPrices["put_Down_Out"];

            //Formula to calcualte Vega: dC/dsig
            double callUpInVega = Math.Round((highSigCallUpInPrice - lowSigCallUpInPrice) / (2 * estimateLevel * sig), 3), 
                putUpInVega = Math.Round((highSigPutUpInPrice - lowSigPutUpInPrice) / (2 * estimateLevel * sig), 3);
            double callUpOutVega = Math.Round((highSigCallUpOutPrice - lowSigCallUpOutPrice) / (2 * estimateLevel * sig), 3),
             putUpOutVega = Math.Round((highSigPutUpOutPrice - lowSigPutUpOutPrice) / (2 * estimateLevel * sig), 3);
            double callDownInVega = Math.Round((highSigCallDownInPrice - lowSigCallDownInPrice) / (2 * estimateLevel * sig), 3),
             putDownInVega = Math.Round((highSigPutDownInPrice - lowSigPutDownInPrice) / (2 * estimateLevel * sig), 3);
            double callDownOutVega = Math.Round((highSigCallDownOutPrice - lowSigCallDownOutPrice) / (2 * estimateLevel * sig), 3),
             putDownOutVega = Math.Round((highSigPutDownOutPrice - lowSigPutDownOutPrice) / (2 * estimateLevel * sig), 3);
            #endregion

            table1.Rows.Add("Thoretical Price", call_Up_In_Price, put_Up_In_Price, call_Up_Out_Price, put_Up_Out_Price, 
                call_Down_In_Price, put_Down_In_Price, call_Down_Out_Price, put_Down_Out_Price);
            table1.Rows.Add("Delta", callUpInDelta, putUpInDelta, callUpOutDelta, putUpOutDelta, callDownInDelta, putDownInDelta, callDownOutDelta, putDownOutDelta);
            table1.Rows.Add("Gamma", callUpInGamma, putUpInGamma, callUpOutGamma, putUpOutGamma, callDownInGamma, putDownInGamma, callDownOutGamma, putDownOutGamma);
            table1.Rows.Add("Theta", callUpInTheta, putUpInTheta, callUpOutTheta, putUpOutTheta, callDownInTheta, putDownInTheta, callDownOutTheta, putDownOutTheta);
            table1.Rows.Add("Rho", callUpInRho, putUpInRho, callUpOutRho, putUpOutRho, callDownInRho, putDownInRho, callDownOutRho, putDownOutRho);
            table1.Rows.Add("Vega", callUpInVega, putUpInVega, callUpOutVega, putUpOutVega, callDownInVega, putDownInVega, callDownOutVega, putDownOutVega);
            table1.Rows.Add("Standard Error", call_Up_In_StandardError, put_Up_In_StandardError, call_Up_Out_StandardError, put_Up_Out_StandardError, call_Down_In_StandardError, put_Down_In_StandardError, call_Down_Out_StandardError, put_Down_Out_StandardError);
            #endregion

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

            #region Timer
            timerTable.Columns.Add("Time", typeof(double));
            timerTable.Rows.Add(AlgoTime);
            #endregion

            return dataSet;
        }

    }
}

