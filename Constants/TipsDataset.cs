using MeuRastroCarbonoAPI.Models.Enums;
using MeuRastroCarbonoAPI.Models.Payload.Tips;
using static MeuRastroCarbonoAPI.Models.Payload.Tips.TipsModel;

namespace MeuRastroCarbonoAPI.Constants
{
    public static class TipsDataset
    {
        public static List<TipsModel> waterTips = new List<TipsModel>
        {
            new TipsModel("Vazão do chuveiro", SurveyType.Water, TipCategory.ShowerBath, "Utilize chuveiros que por padrão possuam uma vazão menor de água e/ou instale redutores de vazão de água.", "https://portal.loft.com.br/como-economizar-agua/?utm_source=google&utm_medium=cpc&utm_campaign=sls_01_br_001_sp_0001_sao-paulo_all_all_aw_pmax_conversion_broad&utm_content=performance_max&utm_id=17818777639&utm_placement=&utm_ad_id=&gclid=Cj0KCQjw98ujBhCgARIsAD7QeAiCKEQcNxe4mqLwe9t0O_SVM-d-iO4tTrdur6HrqTz6hOGuIXHCYzwaAjkuEALw_wcB"),
            new TipsModel("Corrija vazamentos", SurveyType.Water,TipCategory.Water, "Uma torneira que goteja chega a desperdiçar 960 litros de água em um mês. Fazer a manutenção não só economiza agua, como reduz custos.", "https://portal.loft.com.br/como-economizar-agua/?utm_source=google&utm_medium=cpc&utm_campaign=sls_01_br_001_sp_0001_sao-paulo_all_all_aw_pmax_conversion_broad&utm_content=performance_max&utm_id=17818777639&utm_placement=&utm_ad_id=&gclid=Cj0KCQjw98ujBhCgARIsAD7QeAiCKEQcNxe4mqLwe9t0O_SVM-d-iO4tTrdur6HrqTz6hOGuIXHCYzwaAjkuEALw_wcB"),
            new TipsModel("Escovação de dentes", SurveyType.Water, TipCategory.Water, "Escove os dentes com a torneira fechada.", ""),
            new TipsModel("Economize água ao lavar louça", SurveyType.Water, TipCategory.Water,  "Remova os resíduos, ensabõe toda a louça e finalmente enxágue.",""),
            new TipsModel("Regar as plantas", SurveyType.Water, TipCategory.Water, "Utilize regador para lavar as plantas, ao invés de mangueira. Você pode economizar até 96 litros de água a cada 10 minutos.", "https://portal.loft.com.br/como-economizar-agua/?"),
        };

        public static List<TipsModel> foodTips = new List<TipsModel>
        {
            new TipsModel("Dieta low-carbon", SurveyType.Food, TipCategory.FoodShop, "Dê preferência a frutas e vegetais.", "https://coolcalifornia.arb.ca.gov/low-carbon-diet"),
            new TipsModel("Compostagem", SurveyType.Food, TipCategory.FoodShop, "Faça a compostagem do lixo orgânico,ou descarte para insituições que fazem a tarefa.", "https://coolcalifornia.arb.ca.gov/low-carbon-diet"),
            new TipsModel("Separação do lixo", SurveyType.Food, TipCategory.FoodShop, "Separe o lixo e descarte apropriadamente os recicláveis.", ""),
            new TipsModel("No mercado", SurveyType.Food, TipCategory.FoodShop, "Procure consumir produtos de marcas sustentáveis.", ""),
            new TipsModel("", SurveyType.Food, TipCategory.FoodShop, "Evite comprar de forma compulsória, e procure consertar itens ao invés de comprar um novo.", ""),
        };

        public static List<TipsModel> electronicsTips = new List<TipsModel>
        {
            new TipsModel("Dispositivos", SurveyType.Electronics, TipCategory.Cellphone, "Retire os dispositivos da tomada quando não estivem em uso", "https://coolcalifornia.arb.ca.gov/efficient-home"),
            new TipsModel("Desperdício", SurveyType.Electronics, TipCategory.Electricity, "Utilize dispositivos inteligentes para desligar automaticamente dispositivos que não estão em uso.", "https://coolcalifornia.arb.ca.gov/efficient-home"),
            new TipsModel("Redução de gasto energético", SurveyType.Electronics, TipCategory.IncandescentLamp, "Substitua lâmpadas comuns por lâmpadas de LED.", "https://repositorio.ufsc.br/bitstream/handle/123456789/203966/TCC%20Final.pdf?sequence=1&isAllowed=y"),
            new TipsModel("Utilização de luzes", SurveyType.Electronics, TipCategory.Electricity, "Crie o hábito dedesligar as luzes ao sair dos cômodos.", "https://repositorio.ufsc.br/bitstream/handle/123456789/203966/TCC%20Final.pdf?sequence=1&isAllowed=y"),
            new TipsModel("Abra a janela!", SurveyType.Electronics,TipCategory.Electricity, "Além de ver um lindo dia, pode substituir a necessidade de deixar a lâmpada ligada, além de economizar no fim do mês.", "https://repositorio.ufsc.br/bitstream/handle/123456789/203966/TCC%20Final.pdf?sequence=1&isAllowed=y"),
            new TipsModel("Compra de eletrodomésticos", SurveyType.Electronics, TipCategory.Electricity, "Na proxima vez que forcomprar aparelhos elétricos, considere o consumo de eletricidade como fator um dos fatores de decisão.", "https://repositorio.ufsc.br/bitstream/handle/123456789/203966/TCC%20Final.pdf?sequence=1&isAllowed=y"),
            new TipsModel("Energia mais sustentável", SurveyType.Electronics, TipCategory.Electricity, "Já pensou em aderir a placas fotovoltaicas ou de aquecimento solar em sua residência?", "https://repositorio.ufsc.br/bitstream/handle/123456789/203966/TCC%20Final.pdf?sequence=1&isAllowed=y"),
        };

        public static List<TipsModel> locomotionTips = new List<TipsModel>
        {
            new TipsModel("Ar-condicionado do carro", SurveyType.Locomotion, TipCategory.Car, "Se você precisar do AC, tente ligá-lo quando estiver em uma marcha mais alta para economizar combustível.", "https://ecodrivingusa.com/what-is-eco-driving/"),
            new TipsModel("Eco-driving", SurveyType.Locomotion, TipCategory.Car, "Parar e acelerar pode queimar combustível do tanque. É melhor andar em baixa velocidade do que parar completamente (se aplicável).", "https://ecodrivingusa.com/what-is-eco-driving/"),
            new TipsModel("Eco-driving", SurveyType.Locomotion, TipCategory.Car, "Evite marcha lenta desnecessária no trânsito, pois a prática consome mais combustível", "https://ecodrivingusa.com/what-is-eco-driving/"),
            new TipsModel("", SurveyType.Locomotion, TipCategory.Car, "Mantenha uma velocidade sólida em vez de acelerar constantemente no trânsito – uma velocidade mais baixa tende a economizar combustível.", "https://ecodrivingusa.com/what-is-eco-driving/"),
            new TipsModel("Otimize o do carro", SurveyType.Locomotion, TipCategory.EtanolFuelCar, "Os motores a diesel tendem a ter melhor eficiência de combustível porque consomem menos gasolina para funcionar.", "https://ecodrivingusa.com/what-is-eco-driving/"),
            new TipsModel("Eco-driving", SurveyType.Locomotion, TipCategory.Car, "Mantenha os pneus devidamente calibrados.", "https://transweb.sjsu.edu/sites/default/files/2808-ecodriving-greenhouse-gas-emissions-fuel-use-public-education.pdf"),
            new TipsModel("Eco-driving", SurveyType.Locomotion, TipCategory.Car, "Troque os filtros de ar conforme recomendado pelo fabricante.", "https://transweb.sjsu.edu/sites/default/files/2808-ecodriving-greenhouse-gas-emissions-fuel-use-public-education.pdf"),
            new TipsModel("Eco-driving", SurveyType.Locomotion, TipCategory.Car, "Remova bicicletários e racks de teto quando não necessários.", "https://transweb.sjsu.edu/sites/default/files/2808-ecodriving-greenhouse-gas-emissions-fuel-use-public-education.pdf"),
            new TipsModel("Eco-driving", SurveyType.Locomotion, TipCategory.Car, "Evite deixar o carro em marcha lenta por mais de 30 segundos consecutivos.", "https://transweb.sjsu.edu/sites/default/files/2808-ecodriving-greenhouse-gas-emissions-fuel-use-public-education.pdf"),
            new TipsModel("Higiene do carro", SurveyType.Locomotion, TipCategory.Car, "Procure lavar o carro com baldes, ao invés de mangueira.", ""),
        };
    }
}
