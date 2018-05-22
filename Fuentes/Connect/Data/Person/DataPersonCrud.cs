using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity.Person;


namespace Data.Person
{
    public class DataPersonCrud
    {
        public DataTable getPersonCrud(RequestPersonCrud request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                response = db.executeDataTable("spGetPersonCrud", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable personCrud(RequestPersonCrud request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[21];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@firstName", request.firstName);
                param[2] = new SqlParameter("@secondName", request.secondName);
                param[3] = new SqlParameter("@firstLastName", request.firstLastName);
                param[4] = new SqlParameter("@secondLastName", request.secondLastName);
                param[5] = new SqlParameter("@dateBorn", request.dateBorn);
                param[6] = new SqlParameter("@typeDocument", request.typeDocument);
                param[7] = new SqlParameter("@document", request.document);
                param[8] = new SqlParameter("@homeAddress", request.homeAddress);
                param[9] = new SqlParameter("@homePhone", request.homePhone);
                param[10] = new SqlParameter("@workPhone", request.workPhone);
                param[11] = new SqlParameter("@movilPhone1", request.movilPhone1);
                param[12] = new SqlParameter("@movilPhone2", request.movilPhone2);
                param[13] = new SqlParameter("@profession", request.profession);
                param[14] = new SqlParameter("@workplace", request.workplace);
                param[15] = new SqlParameter("@stateRecord", request.stateRecord);
                param[16] = new SqlParameter("@userRegister", request.userRegister);
                param[17] = new SqlParameter("@dateRegister", request.dateRegister);
                param[18] = new SqlParameter("@userUpdate", request.userUpdate);
                param[19] = new SqlParameter("@dateUpdate", request.dateUpdate);
                param[20] = new SqlParameter("@flag", request.flag);

                response = db.executeDataTable("spPersonCrud", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
