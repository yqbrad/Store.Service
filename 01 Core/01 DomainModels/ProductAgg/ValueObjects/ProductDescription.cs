using Framework.Domain.BaseModels;
using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.ValueObjects
{
    public class ProductDescription : BaseValueObject<ProductDescription>
    {
        public string Value { get; private set; }

        public ProductDescription(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                throw new InvalidValueObjectStateException("توضیحات محصول خالی است");

            Value = value.Trim().Length switch
            {
                < 10 => throw new InvalidValueObjectStateException("توضیحات محصول باید بیشتر از 10 کاراکتر باشد"),
                _ => value.Trim()
            };
        }

        public override bool ObjectIsEqual(ProductDescription otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();

        public static implicit operator string(ProductDescription des) => des.Value;
    }
}