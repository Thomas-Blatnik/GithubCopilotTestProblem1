// This file contains source code modified by GitHub Copilot.

using Microsoft.AspNetCore.Mvc;
using Problem1.Models;

namespace Problem1.Controllers
{
    [ApiController]
    [Route("/")]
    public class MathController : ControllerBase
    {


        [HttpPost]
        public IActionResult Calculate([FromBody] MathRequest request)
        {
            MathResponse response = new MathResponse();

            if(request.Method == "add")
            {
                int sum = 0;
                foreach(int i in request.Inputs)
                {
                    sum += i;
                };

                response.Result = sum;
            }

            if(request.Method == "mode")
            {
                int mode = Mode(request.Inputs);

                response.Result = mode;

            }

            if(request.Method == "mean")
            {
                int mean = Mean(request.Inputs);

                response.Result = mean;
            }

            if(request.Method == "range")
            {
                int range = Range(request.Inputs);

                response.Result = range;
            }

            if(request.Method == "stddev")
            {
                int standardDeviation = StandardDeviation(request.Inputs);
                response.Result = standardDeviation;
            }

            return Ok(response);
        }


        public int Mode(List<int> numbers)
        {
            var groups = numbers.GroupBy(n => n);
            var largestCount = groups.Max(g => g.Count());
            var modes = groups.Where(g => g.Count() == largestCount).Select(g => g.Key).ToList();

            if (modes.Count > 1)
            {
                return 0;
            }

            return modes.Single();
        }

        public int Mean(List<int> numbers)
        {
            double sum = numbers.Sum();
            double mean = sum / numbers.Count;

            return (int)Math.Round(mean, MidpointRounding.AwayFromZero);
        }

        public int Range(List<int> numbers)
        {
            int min = numbers.Min();
            int max = numbers.Max();

            return max - min;
        }

        public int StandardDeviation(List<int> numbers)
        {
            double mean = numbers.Average();
            double sumOfSquaresOfDifferences = numbers.Select(val => (val - mean) * (val - mean)).Sum();
            double standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / numbers.Count);

            return (int)Math.Round(standardDeviation, MidpointRounding.AwayFromZero);
        }
    }
}