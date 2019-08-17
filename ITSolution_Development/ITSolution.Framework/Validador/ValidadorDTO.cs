using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Validador
{
    /// <summary>
    /// Classe para validar os dados do Objeto antes da persistência
    /// </summary>
    public class ValidadorDTO
    {
        /// <summary>
        /// Verifica se o Objeto é válido a partir da anotações feitas.
        /// </summary>
        /// <param colName="entidade"></param>
        /// <returns></returns> Um coleção dos errorList
        public static List<ValidationResult> Validation(object obj)
        {
            //lista para armanezar os errorList
            List<ValidationResult> validationList = new List<ValidationResult>();

            try
            {
                ValidationContext contexto = new ValidationContext(obj, null, null);

                //seta a lista de erros do Objeto informado
                Validator.TryValidateObject(obj, contexto, validationList, true);

            }
            catch (OverflowException ex1)
            {
                LoggerUtilIts.ShowExceptionLogs(ex1);
                throw ex1;
            }
            catch (Exception ex2)
            {
                LoggerUtilIts.ShowExceptionLogs(ex2);
                throw ex2;
            }

            return validationList;
        }

        /// <summary>
        /// Valida o Objeto e exibe uma mensagem informativa de cada erro, os errorList são informados um por um.
        /// </summary>
        /// <param colName="entidade"></param>
        /// <param name="obj"></param>
        /// <returns></returns> true se ok caso contrário false
        public static bool Validate(object obj)
        {
            try
            {
                List<ValidationResult> validationList = Validation(obj);
                foreach (var erro in validationList)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Valida o Objeto e exibe uma mensagem informativa de cada erro, os errorList são informados um por um.
        /// </summary>
        /// <param colName="entidade"></param>
        /// <param name="obj"></param>
        /// <returns></returns> true se ok caso contrário false
        public static bool ValidateWarning(object obj)
        {
            try
            {
                List<ValidationResult> validationList = Validation(obj);
                foreach (var erro in validationList)
                {
                    XMessageIts.Mensagem(erro.ToString());
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Valida o Objeto e exibe uma mensagem informativa de todos os erros;
        /// </summary>
        /// <param colName="entidade"></param>
        /// <param name="obj"></param>
        /// <returns></returns> true se ok caso contrário false
        public static bool ValidateWarningAll(object obj)
        {
            try
            {
                List<ValidationResult> validationList = Validation(obj);

                string errorList = "";
                foreach (var erro in validationList)
                {
                    if(erro != null)
                        errorList = errorList + erro.ToString() + "\n\n";
                }

                if (!String.IsNullOrWhiteSpace(errorList))
                {
                    XMessageIts.Advertencia(errorList, "Atenção - Dados inválidos");
                    return false;
                }
                return true;
            }
            catch (System.ArgumentNullException ex)
            {
                Console.WriteLine("Validação cancelada: objeto nulo" );
                LoggerUtilIts.ShowExceptionMessage(ex);
                return false;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Valida uma lista de objetos e exibe todas as mensagem em um MessageBox.
        /// </summary>
        /// <param colName="entidade"></param>
        /// <param name="objList"></param>
        /// <returns></returns> true se ok caso contrário false
        public static bool ValidateListWarningAll<T>(ICollection<T> objList) where T : new()
        {
            if (objList == null)
                XMessageIts.Advertencia("Coleção não informada para validação");

            string errorList = "";

            foreach (var obj in objList)
            {
                try
                {
                    List<ValidationResult> validationList = Validation(obj);

                    if (validationList.Count == 0)
                        return true;
                    foreach (var errorMsg in validationList)
                    {
                        errorList = errorList + errorMsg.ToString() + "\n";
                    }

                    var hr = "==============================================================================\n";
                    errorList = errorList + hr + "\n";
                }
                catch (Exception ex)
                {
                    XMessageIts.Erro("Entidade nula tentou ser válidada.","Atenção!!!");
                    LoggerUtilIts.GenerateLogs(ex);
                }
            }

            if (!String.IsNullOrWhiteSpace(errorList))
            {
                XMessageIts.Advertencia(errorList, "Dados inválidos");
                return false;
            }
            return true;
        }
    }
}