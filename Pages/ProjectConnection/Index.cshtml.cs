using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;

namespace PortfolioProject.Pages.ProjectConnection
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioProject.Data.ApplicationDbContext _context;

        public IndexModel(PortfolioProject.Data.ApplicationDbContext context)
        {
            _context = context;

        }

        public IList<Connection> Connection { get; set; }

      
public async Task OnGetAsync()
        {
            Connection = await _context.Connections.ToListAsync();

        }

        //IDEA INQUIRY FORM LEVELS FOR MENTORSHIP
        /*
        STEP#1 - ASK USING CONSOLE.WRITELINE()
         CAN YOU PROVIDE GUIDANCE REGARDING QUESTIONS(EXAMPLE LEVEL 1)
                IF YES CONSOLE.READLINE() - KEEP INPUT ANSWER
                IF NO CONSOLE.READLINE() - KEEP INPUT ANSWER
        STEP#2 - CONTINUE LOOP THROUGH EACH LEVEL OF MENTORSHIP
        STEP#3 - KEEP INPUT OF EACH ANSWER
        STEP#4 - CALCULATE INPUT OF EACH ANSWER
        STEP#5 - RESULT OF ANSWER
                CONSOLE.WRITE LINE("YOU ARE A LEVEL 1,2,3,4 MENTOR)
        STEP#6 - SEND MESSAGE TO MENTOREE TO BEGIN MENTORSHIP
        *******************************************************
        
        <H4> MENTORSHIP LEVELS>
        DISPLAY IMAGE OF LEVELS IN HEADER
        ********************************************************
        VARIABLES
        string ResultYes { get; set; } EXAMPLE (yes/no)
        string ResultNo { get; set; } EXAMPLE (yes/no)
        string Level1 { get; set; }
        string Level2 { get; set; }
        string Level3 { get; set; }
        string Level4 { get; set; }
        string ResultFinal { get; set; } EXAMPLE Take string ResultYes values or string ResultNo values
        *************************************************
        1st prompt in form 
        Console.Writeline string LevelOne = ("AS A MENTOR, CAN YOU PROVIDE GUIDANCE BY ANSWERING QUESTIONS?");
        Console.Readline();
        if user input = string ResultYes keep LevelOne
        if user input = string ResultNo  do not keep LevelOne
        Loop
        2nd prompt in form
        Console.Writeline string LevelTwo =  ("AS A MENTOR, DO YOU HAVE RESOURCES, BOOKS, TOOLS?");
        Console.Readline();
        if user input = string ResultYes keep data of string LevelTwo
        if user input = string ResultNo  do not keep data of string LevelTwo
        Loop
        3rd prompt in form
        Console.Writeline string LevelThree = ("AS A MENTOR, DO YOU HAVE AVAILABILTY TO MEET FOR CHATS & MEETINGS?");
        Console.Readline();
        if user input = string ResultYes keep LevelThree
        if user input = string ResultNo  do not keep LevelThree
        Loop
        4th prompt in form
        Console.Writeline string LevelFour = ("AS A MENTOR, DO HAVE AVAILABILTY TO ATTEND NETWORKING EVENTS & MEETUPS?");
        Console.Readline();
        if user input = string ResultYes keep LevelFour
        if user input = string ResultNo  do not keep LevelFour

        ResultFinal display Mentor Levels in form 
        Mentor send message to begin Mentorship
        ******************************************************


        */
    //      @}  if (isPost)
    //        {
    //            string levelOne = Request.Form["levelOne"];
    //string levelTwo = Request.Form["levelTwo"];
    //string levelThree = Request.Form["levelThree"];
    //string levelFour = Request.Form["levelFour"];
    //}
    }
}
