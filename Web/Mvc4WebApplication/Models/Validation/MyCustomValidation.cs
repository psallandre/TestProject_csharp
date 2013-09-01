﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4WebApplication.Models.Validation
{
  //http://stackoverflow.com/questions/5390403/datetime-date-and-hour-validation-with-data-annotation
  public class MyDateTimeValidation : RegularExpressionAttribute
  {
    public MyDateTimeValidation()
      : base(@"^((((31\/(0?[13578]|1[02]))|((29|30)\/(0?[1,3-9]|1[0-2])))\/(1[6-9]|[2-9]\d)?\d{2})|(29\/0?2\/(((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))|(0?[1-9]|1\d|2[0-8])\/((0?[1-9])|(1[0-2]))\/((1[6-9]|[2-9]\d)?\d{2})) (20|21|22|23|[0-1]?\d):[0-5]?\d$")
    {
      ErrorMessage = "Date must be in the format of : dd/mm/yyyy hh:mm";
    }
  }

  //http://www.codeproject.com/Articles/422573/Model-Validation-in-ASP-NET-MVC
  public class FutureDateValidatorAttribute : ValidationAttribute, IClientValidatable
  {
    public override bool IsValid(object value)
    {
      return value != null && (DateTime)value > DateTime.Now;
    }

    public IEnumerable<ModelClientValidationRule>
           GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
      yield return new ModelClientValidationRule
      {
        ErrorMessage = ErrorMessage,
        ValidationType = "futuredate"
      };
    }
  }
}