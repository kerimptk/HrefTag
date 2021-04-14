using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Linq;

namespace BaseCore.Aspects.Validation
{
    [PSerializable]
    public class ValidationAspect : OnMethodBoundaryAspect
    {
        public Type Validator;

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(Validator);
            if (Validator.BaseType is null) return;
            var entityType = Validator.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType).ToList();
            var errorMessage = "";
            foreach (var result in from entity in entities where validator != null select validator?.Validate(entity) into result where !result.IsValid select result)
            {
                errorMessage = result.Errors.Aggregate(errorMessage, (current, error) => current + error);
                throw new ValidationException(errorMessage);
            }
        }
    }
}