using DSD01CalculatorForStudents.Operations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace DSD01CalculatorForStudents.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        [Display(Name = "First Number")]
        public double NumberA { get; set; }

        [Display(Name = "Second Number")]
        public double NumberB { get; set; }

        [Display(Name = "Result")]
        public double Result { get; set; }

        public string? OperationSelection { get; set; }

        [Display(Name = "Operation")]
        public List<SelectListItem> Operations = new List<SelectListItem>
        {
            new SelectListItem { Value = "Add", Text = "Add" },
            new SelectListItem { Value = "Subtract", Text = "Subtract" },
            new SelectListItem { Value = "Multiply", Text = "Multiply" },
            new SelectListItem { Value = "Divide", Text = "Divide" }
        };

        //made another list to hold all the answers in the static list, that is bound on the page.
        public List<string> Answers = new List<string>();





        public void OnGet()
        {

        }

        public void OnPost()
        {



            if (OperationSelection == "Add")
                Result = NumberA + NumberB;

            if (OperationSelection == "Subtract")
            {
                Result = NumberA - NumberB;
            }
            if (OperationSelection == "Multiply")
            {
                Result = NumberA * NumberB;
            }
            if (OperationSelection == "Divide")
            {
                Result = NumberA / NumberB;
            }

            // AnswerList.Add($"{NumberA} {OperationSelection} {NumberB} = {Result}");


            //add the data to the static list. where it is stored over all the page refreshes
            StaticAnswerList.AnswerList.Add(NumberA + " " + OperationSelection + " " + NumberB + " = " + Result);

            //pass that data back to the one that is on the front end
            Answers.AddRange(StaticAnswerList.AnswerList);

        }
    }
}