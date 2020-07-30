# QuantitativeTrading

<a href="https://www.dropbox.com/s/ry98p4sbceolbl2/Eagle.exe?dl=1" target="_blank">Windows Desktop Application</a> that prices financial options and manages each trade for the client. 




### SetUp 

1. `$ git clone https://github.com/MagicGary/QuantitativeTrading.git` 

2. open `FlyEaglesFly.sln` using Visual Studio 

3. set `Project Eagle` as startup project to review the Financial Calculator

4. set `Project Golden Egg Nest` as start up project to review Portfolio Management App. 


### Project Eagle
1. Calculating Financial options' prices upon maturity using:

    1.  [Black-Scholes Algorithm](https://en.wikipedia.org/wiki/Black%E2%80%93Scholes_model#Black%E2%80%93Scholes_formula)
    
    2.  [Monte Carlo Simulation](https://www.investopedia.com/terms/m/montecarlosimulation.asp)
    

2. Optimized pricing algorithm to reduce model variance using two Statistical techniques: 


    1.  [Control_Variate](https://www.value-at-risk.net/variance-reduction-with-control-variates-monte-carlo-simulation/)
  
  
    2.  [Antithetic_Variate](http://www.columbia.edu/~ks20/4703-Sigman/4703-07-Notes-ATV.pdf)
  
  
3. Improved algorithm computation speed by 70% using:

  
    1. [.NET Framework Parallel Computing](https://docs.microsoft.com/en-us/dotnet/standard/parallel-processing-and-concurrency) 
  
  
    2. [.NET Background Worker to acheive asynchronized simulation](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=netframework-4.8)
    
 4. Financial Options that it supports: 
  
    * European
    
    * Asian
    
    * Range
    
    * Lookback 
    
    * Barrier
    
    * Digital 

### Project Golden Egg Nest
1. **Portfolio Management App** that a client can price each trade and store/update/delete/read each trade. 

2. Using .NET Entity Framework Database First approach.

3. Using .NET EF LINQ


## Project Captures 
### Price Calculator
![alt text](https://github.com/MagicGary/Trading-App/blob/master/img3.JPG)

### Portfolio Management App 
![alt text](https://github.com/MagicGary/Trading-App/blob/master/img5.JPG)

### EF Data Model
![alt text](https://github.com/MagicGary/Trading-App/blob/master/img4.JPG)



