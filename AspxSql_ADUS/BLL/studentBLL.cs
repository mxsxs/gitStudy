using System.Collections.Generic;
using System.Text;
using threeTest.DAL;
using threeTest.Model;
using System.Data;

namespace threeTest.BLL
{
    public class studentBLL
    {
        public int AddNew(student model)
        {
            return new studentDAL().AddNew(model);
        }

        public bool Delete(int id)
        {
            return new studentDAL().Delete(id);
        }

        public int Update(student model)
        {
            return new studentDAL().Update(model);
        }

        //public student Get(int id)
        //{
        //    return new studentDAL().Get(id);
        //}

        public string[,] Get(int id=0, string uname = "", string upass = "")
        {
            return new studentDAL().Get(id, uname, upass);
        }


        public IEnumerable<student> ListAll()
        {
            return new studentDAL().ListAll();
        }
    }
}
