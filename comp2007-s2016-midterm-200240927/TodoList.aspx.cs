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
            // going with garbage code - CODE DOESN'T EVEN WORK WTF

            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                using (TodoConnection db = new TodoConnection())
                {
                    int rowID = Convert.ToInt32(e.Row.FindControl("TodoID"));
                    Todo todo = (from todoList in db.Todos
                                 where rowID == todoList.TodoID
                                 select todoList).FirstOrDefault();

                    if(todo != null)
                        ((CheckBox)e.Row.FindControl("Completed")).Checked = (todo.Completed == true);
                }
            }
        }
    }
}