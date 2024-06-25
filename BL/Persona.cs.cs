using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Persona
    {
        public static (bool, string, Exception) Add(ML.Persona persona)
        {
            try
            {
                using (DL.UsuarioContext context = new DL.UsuarioContext())
                {
                    int rowAffceted = context.Database.ExecuteSqlRaw($"AddPersona '{persona.Nombre}','{persona.ApellidoPaterno}'," +
                        $"'{persona.ApellidoMaterno}'," +
                        $"'{persona.Direccion}','{persona.Sexo}','{persona.Telefono}'");

                    if (rowAffceted > 0)
                    {
                        return (true, "Se agrego exitosamente", null);

                    }
                    else
                    {
                        return (false, "No se pudo agregar", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public static (bool, string, Exception) Update(ML.Persona persona)
        {
            try
            {
                using (DL.UsuarioContext context = new DL.UsuarioContext())
                {
                    int rowAffceted = context.Database.ExecuteSqlRaw($"UpdatePersona '{persona.IdPersona}','{persona.Nombre}','{persona.ApellidoPaterno}','{persona.ApellidoMaterno}'," +
                        $"'{persona.Direccion}','{persona.Sexo}','{persona.Telefono}'");

                    if (rowAffceted > 0)
                    {
                        return (true, "Se actualizo exitosamente", null);
                    }
                    else
                    {
                        return (false, "No se pudo actualizar", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }

        }
        public static (bool, string, Exception) Delete(int idPersona)
        {
            try
            {
                using (DL.UsuarioContext context = new DL.UsuarioContext())
                {
                    int rowAffceted = context.Database.ExecuteSqlRaw($"DeletePersona '{idPersona}'");

                    if (rowAffceted > 0)
                    {
                        return (true, "Se elimino exitosamente", null);
                    }
                    else
                    {
                        return (false, "No se pudo eliminar", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }

        }


        public static (bool, string, ML.Persona, Exception) GetAll()
        {
            try
            {
                using (DL.UsuarioContext context = new DL.UsuarioContext())
                {
                    var result = (from persona in context.Personas
                                  select new
                                  {
                                      IdPersona = persona.IdPersona,
                                      Nombre = persona.Nombre,
                                      ApellidoParterno = persona.ApellidoPaterno,
                                      ApellidoMaterno = persona.ApellidoMaterno,
                                      Direccion = persona.Direccion,
                                      Sexo = persona.Sexo,
                                      Telefono = persona.Telefono
                                  }).ToList();

                    if (result.Count > 0)
                    {
                        ML.Persona persona = new ML.Persona();
                        persona.PersonaList = new List<ML.Persona>();

                        foreach (var item in result)
                        {
                            ML.Persona objPersona = new ML.Persona();

                            objPersona.IdPersona = item.IdPersona;
                            objPersona.Nombre = item.Nombre;
                            objPersona.ApellidoPaterno = item.ApellidoParterno;
                            objPersona.ApellidoMaterno = item.ApellidoMaterno;
                            objPersona.Direccion = item.Direccion;
                            objPersona.Sexo = item.Sexo;
                            objPersona.Telefono = item.Telefono;
                            
                            persona.PersonaList.Add(objPersona);
                        }

                        return (true, null, persona, null);
                    }
                    else
                    {
                        return (false, "No hay registros existentes", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }

        }

        public static (bool, string, ML.Persona, Exception) GetById(int idPersona)
        {
            try
            {
                using (DL.UsuarioContext context = new DL.UsuarioContext())
                {
                    var result = (from persona in context.Personas
                                  where persona.IdPersona == idPersona
                                  select new
                                  {
                                      IdPersona = persona.IdPersona,
                                      Nombre = persona.Nombre,
                                      ApellidoParterno = persona.ApellidoPaterno,
                                      ApellidoMaterno = persona.ApellidoMaterno,
                                      Direccion = persona.Direccion,
                                      Sexo = persona.Sexo,
                                      Telefono = persona.Telefono
                                  }).SingleOrDefault();

                    if (result.IdPersona > 0)
                    {
                        ML.Persona persona = new ML.Persona();

                        persona.IdPersona = result.IdPersona;
                        persona.Nombre = result.Nombre;
                        persona.ApellidoPaterno = result.ApellidoParterno;
                        persona.ApellidoMaterno = result.ApellidoMaterno;
                        persona.Direccion = result.Direccion;
                        persona.Sexo = result.Sexo;
                        persona.Telefono = result.Telefono;

                        return (true, null, persona, null);
                    }
                    else
                    {
                        return (false, "No existe el registro", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
