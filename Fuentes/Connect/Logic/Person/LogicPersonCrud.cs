using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Person;
using Data.Error;
using Entity.Error;
using Entity.Person;
using System.Data;


namespace Logic.Person
{
    public class LogicPersonCrud
    {
        public ResponsePersonCrudList getPersonCrudList(RequestPersonCrud request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataPersonCrud datPerson = new DataPersonCrud();
                ResponsePersonCrudDetail personCrud;
                ResponsePersonCrudList response = new ResponsePersonCrudList();

                dt = datPerson.getPersonCrud(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponsePersonCrudDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            personCrud = new ResponsePersonCrudDetail();

                            personCrud.id = int.Parse(dr["id"].ToString());
                            personCrud.firstName = dr["firstName"].ToString();
                            personCrud.secondName = dr["secondName"].ToString();
                            personCrud.firstLastName = dr["firstLastName"].ToString();
                            personCrud.secondLastName = dr["secondLastName"].ToString();
                            personCrud.dateBorn = DateTime.Parse(dr["dateBorn"].ToString());
                            personCrud.typeDocument = int.Parse(dr["typeDocument"].ToString());
                            personCrud.document = dr["document"].ToString();
                            personCrud.homeAddress = dr["homeAddress"].ToString();
                            personCrud.homePhone = dr["homePhone"].ToString();
                            personCrud.workPhone = dr["workPhone"].ToString();
                            personCrud.movilPhone1 = dr["movilPhone1"].ToString();
                            personCrud.movilPhone2 = dr["movilPhone2"].ToString();
                            personCrud.profession = int.Parse(dr["profession"].ToString());
                            personCrud.workplace = dr["workplace"].ToString();
                            personCrud.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            personCrud.userRegister = dr["userRegister"].ToString();
                            personCrud.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            personCrud.userUpdate = dr["userUpdate"].ToString();
                            personCrud.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(personCrud);
                        }
                    }
                    else
                    {
                        response.code = 0;
                        response.message = "No se encontraron registros";
                        response.status = 0;
                    }
                }
                else
                {
                    response.code = 0;
                    response.message = "No se encontraron registros";
                    response.status = 0;
                }

                return response;
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                throw exSql;
            }
            catch (Exception ex)
            {
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "PERSON";
                error.method = "getPersonCrudList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }

        public ResponsePersonCrud personCrud(RequestPersonCrud request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataPersonCrud datPerson = new DataPersonCrud();
                ResponsePersonCrud response = new ResponsePersonCrud();

                dt = datPerson.personCrud(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = int.Parse(dt.Rows[0]["code"].ToString());
                        response.message = dt.Rows[0]["message"].ToString();
                        response.status = int.Parse(dt.Rows[0]["state"].ToString());
                    }
                }

                return response;
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                throw exSql;
            }
            catch (Exception ex)
            {
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "PERSON";
                error.method = "personCrud";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }
    }
}
