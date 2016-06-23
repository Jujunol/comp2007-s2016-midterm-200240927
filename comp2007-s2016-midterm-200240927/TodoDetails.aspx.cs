using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_midterm_200240927.Models;

/**
 * Name: John Horne
 * StudentID: 200240927
 * Date: 6/23/16
 */
namespace comp2007_s2016_midterm_200240927
{
    public partial class TodoDetails : System.Web.UI.Page
    {

        /**
         * Runs upon page load and fetches the todo if editing
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Request.QueryString.Count != 0)
            {
                FetchTodo();
            }
        }

        /**
         * Retrives the todo targeted for editing
         */
        private void FetchTodo()
        {
            int todoID = Convert.ToInt32(Request.QueryString["TodoID"]);
            using (TodoConnection db = new TodoConnection())
            {
                Todo todo = (from todoList in db.Todos
                             where todoList.TodoID == todoID
                             select todoList).FirstOrDefault();

                if(todo != null)
                {
                    Name.Text = todo.TodoName;
                    Notes.Text = todo.TodoNotes;
                    Completed.Checked = (todo.Completed == true);
                }
            }
        }

        /**
         * Saves the todo to the database
         */
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            using (TodoConnection db = new TodoConnection())
            {
                Todo todo;

                // check if we're editing or adding
                if (Request.QueryString.Count == 0)
                {
                    todo = new Todo();
                }
                else
                {
                    int todoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    todo = (from todoList in db.Todos
                            where todoList.TodoID == todoID
                            select todoList).FirstOrDefault();
                }

                todo.TodoName = Name.Text;
                todo.TodoNotes = Notes.Text;
                todo.Completed = Completed.Checked;

                if (Request.QueryString.Count == 0)
                {
                    db.Todos.Add(todo);
                }

                db.SaveChanges();
                Response.Redirect("TodoList.aspx");
            }
        }

        /**
         * Discards any edits and redirects
         */
        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TodoList.aspx");
        }
    }
}