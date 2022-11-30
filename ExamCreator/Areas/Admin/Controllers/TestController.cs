using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.Context;
using EntityLayer.Concrete;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        private readonly ECContext _context;

        public TestController(ECContext context)
        {
            _context = context;
        }

        // GET: Admin/Test
        public async Task<IActionResult> Index()
        {
            var eCContext = _context.Questions.Include(q => q.AcademicYear).Include(q => q.CreatUser).Include(q => q.Grade).Include(q => q.ModifyUser).Include(q => q.QuestionLevel).Include(q => q.QuestionType).Include(q => q.Section).Include(q => q.Subject);
            return View(await eCContext.ToListAsync());
        }

        // GET: Admin/Test/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.AcademicYear)
                .Include(q => q.CreatUser)
                .Include(q => q.Grade)
                .Include(q => q.ModifyUser)
                .Include(q => q.QuestionLevel)
                .Include(q => q.QuestionType)
                .Include(q => q.Section)
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Admin/Test/Create
        public IActionResult Create()
        {
            ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Name");
            ViewData["CreatUserId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Name");
            ViewData["ModifyUserId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["QuestionLevelId"] = new SelectList(_context.QuestionLevels, "Id", "Name");
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionTypes, "Id", "Description");
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: Admin/Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,SubjectId,SectionId,QuestionTypeId,QuestionLevelId,GradeId,AcademicYearId,Id,Status,IsDeleted,CreatedDate,ModifyedDate,CreatUserId,ModifyUserId")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.Id = Guid.NewGuid();
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Name", question.AcademicYearId);
            ViewData["CreatUserId"] = new SelectList(_context.Users, "Id", "FullName", question.CreatUserId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Name", question.GradeId);
            ViewData["ModifyUserId"] = new SelectList(_context.Users, "Id", "FullName", question.ModifyUserId);
            ViewData["QuestionLevelId"] = new SelectList(_context.QuestionLevels, "Id", "Name", question.QuestionLevelId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionTypes, "Id", "Description", question.QuestionTypeId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Name", question.SectionId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", question.SubjectId);
            return View(question);
        }

        // GET: Admin/Test/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Name", question.AcademicYearId);
            ViewData["CreatUserId"] = new SelectList(_context.Users, "Id", "FullName", question.CreatUserId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Name", question.GradeId);
            ViewData["ModifyUserId"] = new SelectList(_context.Users, "Id", "FullName", question.ModifyUserId);
            ViewData["QuestionLevelId"] = new SelectList(_context.QuestionLevels, "Id", "Name", question.QuestionLevelId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionTypes, "Id", "Description", question.QuestionTypeId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Name", question.SectionId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", question.SubjectId);
            return View(question);
        }

        // POST: Admin/Test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Content,SubjectId,SectionId,QuestionTypeId,QuestionLevelId,GradeId,AcademicYearId,Id,Status,IsDeleted,CreatedDate,ModifyedDate,CreatUserId,ModifyUserId")] Question question)
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
            ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Name", question.AcademicYearId);
            ViewData["CreatUserId"] = new SelectList(_context.Users, "Id", "FullName", question.CreatUserId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Name", question.GradeId);
            ViewData["ModifyUserId"] = new SelectList(_context.Users, "Id", "FullName", question.ModifyUserId);
            ViewData["QuestionLevelId"] = new SelectList(_context.QuestionLevels, "Id", "Name", question.QuestionLevelId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionTypes, "Id", "Description", question.QuestionTypeId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Name", question.SectionId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", question.SubjectId);
            return View(question);
        }

        // GET: Admin/Test/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.AcademicYear)
                .Include(q => q.CreatUser)
                .Include(q => q.Grade)
                .Include(q => q.ModifyUser)
                .Include(q => q.QuestionLevel)
                .Include(q => q.QuestionType)
                .Include(q => q.Section)
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Admin/Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'ECContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(Guid id)
        {
          return _context.Questions.Any(e => e.Id == id);
        }
    }
}
