using Framework.Domain.BaseModels;
using Store.DomainModels._Exceptions;

namespace Store.DomainModels.ProductAgg.ValueObjects
{
    public class ProductDeliveryPrice : BaseValueObject<ProductDeliveryPrice>
    {
        public decimal Value { get; private set; }

        public ProductDeliveryPrice(decimal value)
        {
            if (value < 0)
                throw new InvalidValueObjectStateException("قیمت تحویل محصول باید بیشتر از صفر ریال باشد");

            Value = value;
        }

        public override bool ObjectIsEqual(ProductDeliveryPrice otherObject)
            => otherObject.Value == Value;

        public override int ObjectGetHashCode()
            => Value.GetHashCode();

        public static implicit operator decimal(ProductDeliveryPrice price) => price.Value;
    }
}