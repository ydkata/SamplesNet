using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnMvc2.Models
{
    /// <summary>
    /// 社員の検索結果を格納します
    /// </summary>
    [Serializable()]
    public class EmployeViewMdl
    {
        public String emp_id { get; set; }
        public String fname { get; set; }
        public String lname { get; set; }
        public Int32 job_id { get; set; }
        public String pub_id { get; set; }
        public String hire_date { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="emp_id">社員ID</param>
        public EmployeViewMdl()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="emp_id">社員ID</param>
        public EmployeViewMdl(global::System.String emp_id, global::System.String fname, global::System.String lname, global::System.Int16 job_id, global::System.String pub_id, global::System.String hire_date)
        {
            this.emp_id = emp_id;
            this.fname = fname;
            this.lname = lname;
            this.job_id = job_id;
            this.pub_id = pub_id;
            this.hire_date = hire_date;
        }


    }
}