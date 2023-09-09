using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exam.Data;
using exam.Models;
using exam.ModelView;

namespace exam.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly examContext _context;

        public QuestionsController(examContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index(int id)
        {
            int examId = id;
            ViewData["ExamId"] = examId;
            return _context.Questions.Where(q => q.ExamsId == examId) != null ?
                        View(await _context.Questions.ToListAsync()) :
                        Problem("Entity set 'examContext.Questions'  is null.");
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create(int Id)
        {
            ViewData["ExamId"] = Id;
            var Model = new Question();
            Model.QuestionsChoices = new List<QuestionsChoices>()
            { new QuestionsChoices(),new QuestionsChoices(),new QuestionsChoices(),new QuestionsChoices()
            };

            return View(Model);
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question, int correct)
        {
            //if (ModelState.IsValid)
            //{
            if (question.Type == QuestionType.FillInTheBlank)
            {
                var originalString = question.Title;
                char startChar = '[';
                char endChar = ']';
                string replacementText = "###";

                string replacedString = ReplaceAllTextBetweenChars(originalString, startChar, endChar, replacementText);
                originalString = originalString.Replace('[', ' ');
                question.Answer.Answer = originalString.Replace(']', ' ');

                replacedString = replacedString.Replace('[', ' ');
                replacedString = replacedString.Replace(']', ' ');
                question.Title = replacedString;
            }
            if (question.Type == QuestionType.choice)
            {
                question.QuestionsChoices[correct - 1].IsCoreect = true;
            }
            else
            {
                question.QuestionsChoices = null;
            }
            question.Id = 0;
            _context.Add(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'examContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        static string ReplaceAllTextBetweenChars(string inputString, char startChar, char endChar, string replacementText)
        {
            int startIndex = inputString.IndexOf(startChar);
            while (startIndex != -1)
            {
                int endIndex = inputString.IndexOf(endChar, startIndex);
                if (endIndex != -1)
                {
                    string beforeText = inputString.Substring(0, startIndex + 1);
                    string afterText = inputString.Substring(endIndex);

                    inputString = beforeText + replacementText + afterText;

                    // Look for the next occurrence starting after the current end index
                    startIndex = inputString.IndexOf(startChar, endIndex);
                }
                else
                {
                    break; // End character not found, exit loop
                }
            }

            return inputString;
        }

    }
}
