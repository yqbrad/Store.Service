using Framework.Domain.BaseModels;
using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.ValueObjects
{
    public class ProductName : BaseValueObject<ProductName>
    {
        public string Value { get; private set; }

        public ProductName(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                throw new InvalidValueObjectStateException("نام محصول خالی است");

            Value = value.Trim().Length switch
            {
                < 3 => throw new InvalidValueObjectStateException("نام محصول باید بیشتر از 3 کاراکتر باشد"),
                > 200 => throw new InvalidValueObjectStateException("نام محصول باید کمتر از 200 کاراکتر باشد"),
                _ => value.Trim()
            };
        }

        public override bool ObjectIsEqual(ProductName otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();

        public static implicit operator string(ProductName name) => name.Value;
    }
}