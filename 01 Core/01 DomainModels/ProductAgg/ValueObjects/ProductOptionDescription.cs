using Framework.Domain.BaseModels;
using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.ValueObjects
{
    public class ProductOptionDescription : BaseValueObject<ProductOptionDescription>
    {
        public string Value { get; private set; }

        public ProductOptionDescription(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                throw new InvalidValueObjectStateException("توضیحات آپشن محصول خالی است");

            Value = value.Trim().Length switch
            {
                < 10 => throw new InvalidValueObjectStateException("توضیحات آپشن محصول باید بیشتر از 10 کاراکتر باشد"),
                _ => value.Trim()
            };
        }

        public override bool ObjectIsEqual(ProductOptionDescription otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();

        public static implicit operator string(ProductOptionDescription des) => des.Value;
    }
}