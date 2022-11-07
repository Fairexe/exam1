using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FWEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExController : Controller
    {
        // GET: ExController
        [HttpGet]
        public IActionResult CalculateAreaOfRectangle(int height, int width)
        {
            return new JsonResult(height * width);
        }

        [HttpPost]
        public IActionResult CalculateAreaOfTriangle([FromForm] AreaOfTriangleRequest request)
        {
            return new JsonResult(request.Base * request.Height);
        }

        [HttpPost]
        public IActionResult CalculateAvg([FromBody] AvgRequest request)
        {
            int sum = 0;
            for(int i = 0; i < request.input.Length;i++)
            {
                sum = sum + request.input[i];
            }
            return new JsonResult(sum / request.input.Length);
        }

        [HttpGet]
        public IActionResult Range(int max)
        {
            int[] range = new int[max];
            for(int i = 0; i < max; i++)
            {
                range[i] = 1+i;
            }
            return new JsonResult(range);
        }

        [HttpPost]
        public IActionResult ConcatStringArray([FromBody] StringArrayRequest request)
        {
            string[] input1 = new string[request.input1.Length + request.input2.Length];
            int j = 0;
            for(int i = 0;i< input1.Length; i++)
            {
                
                if (i < request.input1.Length)
                {
                    input1[i] = request.input1[i];
                }
                else
                {
                    input1[i] = request.input2[j];
                    j++;
                }
            }
            
            return new JsonResult(input1);
        }

        [HttpGet]
        public IActionResult RepeatString(string input, int count)
        {
            string repeatStr = "";
            for(int i = 0; i < count; i++)
            {
                repeatStr = repeatStr + input;
            }
            return new JsonResult(repeatStr);
        }

        [HttpPost]
        public IActionResult CalculateMin([FromBody] CalculateMinRequest request)
        {
            int min = request.input[0];
            for(int i = 0; i < request.input.Length; i++)
            {
                if (request.input[i] < min)
                {
                    min = request.input[i];
                }
            }
            return new JsonResult(min);
        }

        [HttpPost]
        public IActionResult FindIndex([FromBody] FindIndexRequest request)
        {
            for(int i = 0; i < request.intArray.Length; i++)
            {
                if (request.intArray[i] == request.valueToFind)
                {
                    return new JsonResult(i);
                }
            }
            return new JsonResult("not found");
        }

        [HttpPost]
        public IActionResult GetUppercase(string input)
        {
 
            return new JsonResult(input.ToUpper());
        }

        [HttpPost]
        public IActionResult DivRem([FromForm] DivRemRequest request)
        {
            int quotient = request.numerator / request.denominator;
            int remainder = request.numerator % request.denominator;
            Div result = new Div { numerator = quotient, denominator = remainder };
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult RemoveOdd([FromBody] RemoveOddRequest request)
        {
            List<int> odd = new List<int>();
            for (int i = 0;i < request.input.Length;i++)
            {
                if (request.input[i] %2 == 0)
                {
                    odd.Add(request.input[i]);
                }
            }
            return new JsonResult(odd);
        }

        [HttpPost]
        public IActionResult RemoveEven([FromBody] RemoveOddRequest request)
        {
            List<int> odd = new List<int>();
            for (int i = 0; i < request.input.Length; i++)
            {
                if (request.input[i] % 2 != 0)
                {
                    odd.Add(request.input[i]);
                }
            }
            return new JsonResult(odd);
        }

        [HttpPost]
        public IActionResult ReverseArray([FromForm] ReverseArrayRequest request)
        {
            List<string> odd = new List<string>();
            for (int i = request.input.Length-1; i >= 0; i--)
            {
                odd.Add(request.input[i]);
            }
            return new JsonResult(odd);
        }

        [HttpPost]
        public IActionResult Intersect2Array([FromBody] Intersect2ArrayRequest request)
        {
            List<string> array3 = new List<string>();
            for (int i = 0; i < request.array1.Length; i++)
            {
                for (int j = 0; j < request.array2.Length; j++)
                {
                    if (request.array1[i].Equals(request.array2[j]))
                    {
                        array3.Add(request.array1[i]);
                    }
                }
            }
            return new JsonResult(array3);
        }

        [HttpPost]
        public IActionResult Union2Array([FromBody] Union2ArrayRequest request)
        {
            List<string> array3 = new List<string>();
            bool check = false;
            foreach(String i in request.array1)
            {
                array3.Add(i);
            }
            for(int i = 0; i < request.array2.Length; i++)
            {
                check = false;
                for(int j = 0; j < array3.Count; j++)
                {
                    if (array3[j].Equals(request.array2[i]))
                    {
                        check = true;
                    }
                }
                if(check == false)
                {
                    array3.Add(request.array2[i]);
                }
            }
            return new JsonResult(array3);
        }

        [HttpPost]
        public IActionResult Array1MinusArray2([FromBody] Array1MinusArray2Request request)
        {
            List<string> array3 = new List<string>();
            bool check = false;
            for(int i = 0; i < request.array1.Length; i++)
            {
                check = false;
                for(int j = 0;j<request.array2.Length; j++)
                {
                    if (request.array1[i].Equals(request.array2[j]))
                    {
                        check = true;
                    }
                }
                if(check == false)
                {
                    array3.Add(request.array1[i]);
                }
            }
            return new JsonResult(array3);
        }

        [HttpPost]
        public IActionResult Substring(string input, int startIndex, int count)
        {
            string str = "";
            for(int i = startIndex; i <= count; i++)
            {
                str +=input[i];
            }

            return new JsonResult(str);
        }

        public class Array1MinusArray2Request
        {
            public string[] array1 { get; set; }
            public string[] array2 { get; set; }
        }

        public class Union2ArrayRequest
        {
            public string[] array1 { get; set; }
            public string[] array2 { get; set; }
        }

        public class Intersect2ArrayRequest
        {
            public string[] array1 { get; set; }
            public string[] array2 { get; set; }
        }

        public class ReverseArrayRequest
        {
            public string[] input { get; set; }
        }

        public class RemoveEvenRequest
        {
            public int[] input { get; set; }
        }

        public class RemoveOddRequest
        {
            public int[] input { get; set; }
        }

        public class DivRemRequest
        {
            public int numerator { get; set; }
            public int denominator { get; set; }
        }

        public class Div
        {
            public int numerator { get; set; }
            public int denominator { get; set; }


        }

        public class FindIndexRequest
        {
            public int[] intArray { get; set; }
            public int valueToFind { get; set; }
        }

        public class CalculateMinRequest
        {
            public int[] input { get; set; }
        }

        public class StringArrayRequest
        {
            public string[] input1 { get; set; }
            public string[] input2 { get; set; }
        }

        public class AvgRequest
        {
            public int[] input { get; set; }
        }

        public class AreaOfTriangleRequest
        {

            public int Base { get; set; }

            public int Height { get; set; }
        }
    }
}
