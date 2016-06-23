using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_midterm_200240927.Models;

namespace comp2007_s2016_midterm_200240927
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.FetchTodoList();
            }
        }

        private void FetchTodoList()
        {
            using(TodoConnection db = new TodoConnection())
            {
                var todos = (from todoList in db.Todos
                             select todoList);

                TodoGridView.DataSource = todos.ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    IQueryable dataSource = ((IQueryable)TodoGridView.DataSource).AsQueryable().Whe;
            //    ((CheckBox)e.Row.FindControl("Completed")).Checked = dataSource.
            //}

            // Couln't figure out efficient way, to populate checkbox values
            // going with inefficient code

            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                using (TodoConnection db = new TodoConnection())
                {
                    int todoID = Convert.ToInt32(TodoGridView.DataKeys[e.Row.RowIndex].Values[0]);
                    Todo todo = (from todoList in db.Todos
                                 where todoID == todoList.TodoID
                                 select todoList).FirstOrDefault();

                    if(todo != null)
                        ((CheckBox)e.Row.FindControl("Completed")).Checked = (todo.Completed == true);
                }
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int todoID = Convert.ToInt32(TodoGridView.DataKeys[e.RowIndex].Values[0]);

            using (TodoConnection db = new TodoConnection())
            {
                Todo todo = (from todoList in db.Todos
                             where todoList.TodoID == todoID
                             select todoList).FirstOrDefault();

                if (todo != null)
                {
                    db.Todos.Remove(todo);
                    db.SaveChanges();
                }
            }

            // refresh the grid
            this.FetchTodoList();
        }

        protected void Completed_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox checkbox = (CheckBox)sender;
            //using (TodoConnection db = new TodoConnection())
            //{
            //    int todoID = Convert.ToInt32(checkbox.);
            //    Todo todo = (from todoList in db.Todos
            //                 where todoID == todoList.TodoID
            //                 select todoList).FirstOrDefault();

            //    if (todo != null)
            //    {
            //        todo
            //    }
            //}
        }
    }
}