using Framework.Domain.BaseModels;
using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.ValueObjects
{
    public class ProductOptionName : BaseValueObject<ProductOptionName>
    {
        public string Value { get; private set; }

        public ProductOptionName(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                throw new InvalidValueObjectStateException("نام آپشن محصول خالی است");

            Value = value.Trim().Length switch
            {
                < 3 => throw new InvalidValueObjectStateException("نام آپشن محصول باید بیشتر از 3 کاراکتر باشد"),
                > 200 => throw new InvalidValueObjectStateException("نام آپشن محصول باید کمتر از 200 کاراکتر باشد"),
                _ => value.Trim()
            };
        }

        public override bool ObjectIsEqual(ProductOptionName otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();

        public static implicit operator string(ProductOptionName name) => name.Value;
    }
}