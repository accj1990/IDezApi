using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IDezApi.Domain.Helpers
{
    public static class EnumHelper<TEnum> where TEnum : struct, Enum
    {
        // Retorna todos os pares Valor + Descrição
        public static List<(TEnum Value, string Description)> GetValuesWithDescriptions()
        {
                    return ((TEnum[])Enum.GetValues(typeof(TEnum)))
                        .Select(e => (e, GetDescription(e)))
                        .ToList();
        }

        // Pega a descrição de um valor do enum
        public static string GetDescription(TEnum value)
        {
            FieldInfo? field = typeof(TEnum).GetField(value.ToString());

            if (field == null)
                return value.ToString();

            // Tenta pegar DescriptionAttribute
            var descAttr = field.GetCustomAttribute<DescriptionAttribute>(false);
            if (descAttr != null)
                return descAttr.Description;

            // Tenta pegar DisplayAttribute
            var displayAttr = field.GetCustomAttribute<DisplayAttribute>(false);
            if (displayAttr != null)
                return displayAttr.Name ?? value.ToString();

            return value.ToString();
        }

        // Pega o valor numérico do enum
        public static int GetIntValue(TEnum value)
        {
            return Convert.ToInt32(value);
        }
    }


}
