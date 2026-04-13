namespace TFGCalculator.Services;

using TFGCalculator.Models;

public class ItemService
{
    /// Все предметы, сгруппированные по модпаку.
    /// Добавляйте новые предметы в соответствующий список.
    private readonly Dictionary<string, List<GameItem>> _items = new()
    {
        ["tfg-0.12.3"] = new List<GameItem>
        {
            new GameItem
            {
                Id = "planks",
                NameRu = "Любые доски",
                NameEn = "Any planks",
                Type = "Дерево",
                Tag = "#minecraft:planks",
                IconPath = "images/items/planks.png"
            },
            new GameItem
            {
                Id = "wooden_slabs",
                NameRu = "Любые деревянные полублоки",
                NameEn = "Any wooden slabs",
                Type = "Дерево",
                Tag = "#minecraft:wooden_slabs",
                IconPath = "images/items/wooden_slabs.png"
            },
            new GameItem
            {
                Id = "wooden_stairs",
                NameRu = "Любые деревянные ступеньки",
                NameEn = "Any wooden stairs",
                Type = "Дерево",
                Tag = "#minecraft:wooden_stairs",
                IconPath = "images/items/wooden_stairs.png"
            },
            new GameItem
            {
                Id = "wooden_fences",
                NameRu = "Любые деревянные заборы",
                NameEn = "Any wooden fences",
                Type = "Дерево",
                Tag = "#minecraft:wooden_fences",
                IconPath = "images/items/wooden_fences.png"
            },
            new GameItem
            {
                Id = "wooden_fence_gates",
                NameRu = "Любые деревянные калитки",
                NameEn = "Any wooden fence gates",
                Type = "Дерево",
                Tag = "#minecraft:wooden_fence_gates",
                IconPath = "images/items/wooden_fence_gates.png"
            },
            new GameItem
            {
                Id = "wooden_doors",
                NameRu = "Любые деревянные двери",
                NameEn = "Any wooden doors",
                Type = "Дерево",
                Tag = "#minecraft:wooden_doors",
                IconPath = "images/items/wooden_doors.png"
            },
            new GameItem
            {
                Id = "wooden_trapdoors",
                NameRu = "Любые деревянные люки",
                NameEn = "Any wooden trapdoors",
                Type = "Дерево",
                Tag = "#minecraft:wooden_trapdoors",
                IconPath = "images/items/wooden_trapdoors.png"
            },
            new GameItem
            {
                Id = "wooden_pressure_plates",
                NameRu = "Любые деревянные нажимные пластины",
                NameEn = "Any wooden pressure plates",
                Type = "Дерево",
                Tag = "#minecraft:wooden_pressure_plates",
                IconPath = "images/items/wooden_pressure_plates.png"
            },
            new GameItem
            {
                Id = "wooden_buttons",
                NameRu = "Любые деревянные ступеньки",
                NameEn = "Any wooden buttons",
                Type = "Дерево",
                Tag = "#minecraft:wooden_buttons",
                IconPath = "images/items/wooden_buttons.png"
            },
            new GameItem
            {
                Id = "stone",
                NameRu = "Любой камень",
                NameEn = "Any stone",
                Type = "Камень",
                Tag = "forge:stone",
                IconPath = "images/items/stone.png"
            },
            new GameItem
            {
                Id = "cobblestone",
                NameRu = "Любой булыжник",
                NameEn = "Any cobblestone",
                Type = "Камень",
                Tag = "forge:cobblestone",
                IconPath = "images/items/cobblestone.png"
            },
            new GameItem
            {
                Id = "gravel",
                NameRu = "Любой гравий",
                NameEn = "Any gravel",
                Type = "Камень",
                Tag = "forge:gravel",
                IconPath = "images/items/gravel.png"
            },
            new GameItem
            {
                Id = "sand",
                NameRu = "Любой песок",
                NameEn = "Any sand",
                Type = "Песок",
                Tag = "forge:sand",
                IconPath = "images/items/sand.png"
            },
            new GameItem
            {
                Id = "glass",
                NameRu = "Любое стекло",
                NameEn = "Any glass",
                Type = "Стекло",
                Tag = "#forge:glass",
                IconPath = "images/items/glass.png"
            },
            new GameItem
            {
                Id = "glass_panes",
                NameRu = "Любые стеклянные панели",
                NameEn = "Any glass panes",
                Type = "Стекло",
                Tag = "#forge:glass_panes",
                IconPath = "images/items/glass_panes.png"
            },
            // ==========================================
            //                    ПЫЛЬ
            // ==========================================
            new GameItem
            {
                Id = "redstone",
                NameRu = "Редстоуновая пыль",
                NameEn = "Redstone dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bone_meal",
                NameRu = "Костная мука",
                NameEn = "Bone meal",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "glowstone_dust",
                NameRu = "Светокаменная пыль",
                NameEn = "Glowstone dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gunpowder",
                NameRu = "Порох",
                NameEn = "Gunpowder",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sugar",
                NameRu = "Сахар",
                NameEn = "Sugar",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "kaolinite_powder",
                NameRu = "Каолинитовый порошок",
                NameEn = "Kaolinite powder",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "yellow_garnet_dust",
                NameRu = "Жёлтый гранат (Пыль)",
                NameEn = "Yellow garnet dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polycaprolactam_dust",
                NameRu = "Поликапролактам (Пыль)",
                NameEn = "Polycaprolactam (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "red_alloy_dust",
                NameRu = "Красный сплав (Пыль)",
                NameEn = "Red alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tetrahedrite_dust",
                NameRu = "Тетраэдрит (Пыль)",
                NameEn = "Tetrahedrite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "asurine_dust",
                NameRu = "Азурин (Пыль)",
                NameEn = "Asurine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sulfur_dust",
                NameRu = "Сера (Пыль)",
                NameEn = "Sulfur (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "neutronium_dust",
                NameRu = "Нейтроний (Пыль)",
                NameEn = "Neutronium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ash_dust",
                NameRu = "Зола",
                NameEn = "Ash",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cobaltite_dust",
                NameRu = "Кобальтит (Пыль)",
                NameEn = "Cobaltite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_cyanide_dust",
                NameRu = "Цианистый калий (Пыль)",
                NameEn = "Potassium cyanide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "platinum_sludge_residue_dust",
                NameRu = "Остаток платинового шлама",
                NameEn = "Platinum sludge residue",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "raw_rubber_dust",
                NameRu = "Необработанная резина (Пыль)",
                NameEn = "Raw rubber (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "uranium_dust",
                NameRu = "Уран 238 (Пыль)",
                NameEn = "Uranium 238 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "chromite_dust",
                NameRu = "Хромит (Пыль)",
                NameEn = "Chromite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "thermochemically_treated_hardwood_dust",
                NameRu = "Обработанная масса из твёрдого дерева",
                NameEn = "Thermochemically treated hardwood dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bauxite_slag_dust",
                NameRu = "Бокситовый шлак (Пыль)",
                NameEn = "Bauxite slag (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts",
            },
            new GameItem
            {
                Id = "ruthenium_tetroxide_dust",
                NameRu = "Тетраоксид рутения (Пыль)",
                NameEn = "Ruthenium tetroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "plutonium_241_dust",
                NameRu = "Плутоний-241 (Пыль)",
                NameEn = "Plutonium-241 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "dark_ash_dust",
                NameRu = "Пепел",
                NameEn = "Dark ash",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "wood_dust",
                NameRu = "Масса из мягкого дерева",
                NameEn = "Wood dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "phosphate_dust",
                NameRu = "Фосфат (Пыль)",
                NameEn = "Phosphate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "armalcolite_dust",
                NameRu = "Армалколит (Пыль)",
                NameEn = "Armalcolite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "osmium_tetroxide_dust",
                NameRu = "Тетраоксид осмия (Пыль)",
                NameEn = "Osmium tetroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "platinum_dust",
                NameRu = "Платина (Пыль)",
                NameEn = "Platinum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcium_ferrocyanide_dust",
                NameRu = "Ферроцианид кальция (Пыль)",
                NameEn = "Calcium ferrocyanide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "enriched_naquadah_dust",
                NameRu = "Обогащённыя наквада (Пыль)",
                NameEn = "Enriched naquadah (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "uraninite_dust",
                NameRu = "Уранинит (Пыль)",
                NameEn = "Uraninite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "scheelite_dust",
                NameRu = "Шеелит (Пыль)",
                NameEn = "Scheelite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "mirabilite_dust",
                NameRu = "Мирабилит (Пыль)",
                NameEn = "Mirabilite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "aluminium_dust",
                NameRu = "Алюминий (Пыль)",
                NameEn = "Aluminium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "spodumene_dust",
                NameRu = "Сподумен (Пыль)",
                NameEn = "Spodumene (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ruthenium_dust",
                NameRu = "Рутений (Пыль)",
                NameEn = "Ruthenium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "green_sapphire_dust",
                NameRu = "Зелёный сапфир (Пыль)",
                NameEn = "Green sapphire (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnetic_iron_dust",
                NameRu = "Магнитное железо (Пыль)",
                NameEn = "Magnetic iron (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cassiterite_dust",
                NameRu = "Касситерит (Пыль)",
                NameEn = "Cassiterite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "invar_dust",
                NameRu = "Инвар (Пыль)",
                NameEn = "Invar (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rhenium_dust",
                NameRu = "Рений (Пыль)",
                NameEn = "Rhenium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "duranium_dust",
                NameRu = "Дюраний (Пыль)",
                NameEn = "Duranium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "phosphorus_pentoxide_dust",
                NameRu = "Пятиокись фосфора (Пыль)",
                NameEn = "Phosphorus pentoxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "nickel_dust",
                NameRu = "Никель (Пыль)",
                NameEn = "Nickel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zinc_dust",
                NameRu = "Цинк (Пыль)",
                NameEn = "Zinc (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "watertight_steel_dust",
                NameRu = "Водостойкая сталь (Пыль)",
                NameEn = "Watertight steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "quicklime_dust",
                NameRu = "Негашеная известь (Пыль)",
                NameEn = "Quicklime (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "clay_dust",
                NameRu = "Глина (Пыль)",
                NameEn = "Clay (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "thorium_232_dust",
                NameRu = "Торий 232 (Пыль)",
                NameEn = "Thorium 232 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "iron_dust",
                NameRu = "Железо (Пыль)",
                NameEn = "Iron (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "fullers_earth_dust",
                NameRu = "Смектическая глина",
                NameEn = "Fullers earth (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "osmiridium_dust",
                NameRu = "Осмистый иридий (Пыль)",
                NameEn = "Osmiridium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts",
            },
            new GameItem
            {
                Id = "wulfenite_dust",
                NameRu = "Вульфенит (Пыль)",
                NameEn = "Wulfenite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cobalt_dust",
                NameRu = "Кобальт (Пыль)",
                NameEn = "Cobalt (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hsla_steel_dust",
                NameRu = "HSLA сталь (Пыль)",
                NameEn = "HSLA steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcite_dust",
                NameRu = "Кальцит (Пыль)",
                NameEn = "Calcite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "prussian_blue_dust",
                NameRu = "Берлинская лазурь (Пыль)",
                NameEn = "Prussian blue (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "titanium_tungsten_carbide_dust",
                NameRu = "Вольфрам-титанановый карбид (Пыль)",
                NameEn = "Titanium tungsten carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "arsenic_trioxide_dust",
                NameRu = "Триоксид мышьяка (Пыль)",
                NameEn = "Arsenic trioxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesium_dust",
                NameRu = "Магний (Пыль)",
                NameEn = "Magnesium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "salt_dust",
                NameRu = "Соль (Пыль)",
                NameEn = "Salt (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bornite_dust",
                NameRu = "Борнит (Пыль)",
                NameEn = "Bornite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bauxite_dust",
                NameRu = "Боксит (Пыль)",
                NameEn = "Bauxite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polyvinyl_butyral_dust",
                NameRu = "Поливинилбутираль (Пыль)",
                NameEn = "Polyvinyl butyral (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "emerald_dust",
                NameRu = "Изумруд (Пыль)",
                NameEn = "Emerald (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "borosilicate_glass_dust",
                NameRu = "Боросиликатное стекло (Пыль)",
                NameEn = "Borosilicate glass (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "soda_ash_dust",
                NameRu = "Сода (Пыль)",
                NameEn = "Soda ash (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "manganese_dust",
                NameRu = "Марганец (Пыль)",
                NameEn = "Manganese (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesite_dust",
                NameRu = "Магнезит (Пыль)",
                NameEn = "Magnesite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_dichromate_dust",
                NameRu = "Дихромат калия (Пыль)",
                NameEn = "Potassium dichromate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "niobium_titanium_dust",
                NameRu = "Ниобий-титан (Пыль)",
                NameEn = "Niobium titanium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ferrosilite_dust",
                NameRu = "Ферросилит (Пыль)",
                NameEn = "Ferrosilite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "silver_dust",
                NameRu = "Серебро (Пыль)",
                NameEn = "Silver (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "soapstone_dust",
                NameRu = "Мыльный камень (Пыль)",
                NameEn = "Soapstone (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "diatomite_dust",
                NameRu = "Диатомовый пилит (Пыль)",
                NameEn = "Diatomite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "olivine_dust",
                NameRu = "Оливин (Пыль)",
                NameEn = "Olivine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rhodium_dust",
                NameRu = "Родий (Пыль)",
                NameEn = "Rhodium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hsss_dust",
                NameRu = "HSS-S (Пыль)",
                NameEn = "HSS-S (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "molybdenum_dust",
                NameRu = "Молибден (Пыль)",
                NameEn = "molybdenum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "quartzite_dust",
                NameRu = "Кварц (Пыль)",
                NameEn = "Quartzite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polyphenylene_sulfide_dust",
                NameRu = "Полифениленсульфид (Пыль)",
                NameEn = "Polyphenylene sulfide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "raw_styrene_butadiene_rubber_dust",
                NameRu = "Стирол-бутадиеновый каучук (Пыль)",
                NameEn = "Raw styrene butadiene rubber (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tin_dust",
                NameRu = "Олово (Пыль)",
                NameEn = "Tin (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rocket_alloy_t1_dust",
                NameRu = "Красный алюминиево-стальной ракетный сплав (Пыль)",
                NameEn = "Rocket alloy t1 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "vanadium_magnetite_dust",
                NameRu = "ванадий магнетит (Пыль)",
                NameEn = "Vanadium magnetite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "metal_mixture_dust",
                NameRu = "Металлическая смесь (Пыль)",
                NameEn = "Metal mixture (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hastelloy_x_dust",
                NameRu = "Хастеллой-X (Пыль)",
                NameEn = "Hastelloy-X (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "niobium_nitride_dust",
                NameRu = "Нитрид ниобия (Пыль)",
                NameEn = "Niobium nitride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesia_dust",
                NameRu = "Магнезия (Пыль)",
                NameEn = "Magnesia (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "titanium_trifluoride_dust",
                NameRu = "Трифторид титана (Пыль)",
                NameEn = "Titanium trifluoride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zeolite_dust",
                NameRu = "Цеолит (Пыль)",
                NameEn = "Zeolite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "powellite_dust",
                NameRu = "Повеллит (Пыль)",
                NameEn = "Powellite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pyrochlore_dust",
                NameRu = "Пирохлор (Пыль)",
                NameEn = "Pyrochlore (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lanthanum_dust",
                NameRu = "Лантан (Пыль)",
                NameEn = "Lanthanum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cupronickel_dust",
                NameRu = "Купроникель (Пыль)",
                NameEn = "Cupronickel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "trona_dust",
                NameRu = "Трона (Пыль)",
                NameEn = "Trona (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "barite_dust",
                NameRu = "Барит (Пыль)",
                NameEn = "Barite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zirconium_dust",
                NameRu = "Цирконий (Пыль)",
                NameEn = "Zirconium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "agar_dust",
                NameRu = "Агар (Пыль)",
                NameEn = "Agar (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "titanium_dust",
                NameRu = "Титан (Пыль)",
                NameEn = "Titanium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_dust",
                NameRu = "Калий (Пыль)",
                NameEn = "Potassiumn (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "almandine_dust",
                NameRu = "Альмандин (Пыль)",
                NameEn = "Almandine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ice_dust",
                NameRu = "Колотый лёд (Пыль)",
                NameEn = "Ice (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "americium_dust",
                NameRu = "Америций 243 (Пыль)",
                NameEn = "Americium 243 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "uranium_235_dust",
                NameRu = "Уран-245 (Пыль)",
                NameEn = "Uranium-235 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "galena_dust",
                NameRu = "Галена (Пыль)",
                NameEn = "Galena (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "antimony_trifluoride_dust",
                NameRu = "Трифторид сурьмы (Пыль)",
                NameEn = "Antimony trifluoride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gallium_dust",
                NameRu = "Галлий (Пыль)",
                NameEn = "Gallium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "californium_252_dust",
                NameRu = "Калифорний 252 (Пыль)",
                NameEn = "Californium 252 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "uranium_triplatinum_dust",
                NameRu = "Триплатина уран (Пыль)",
                NameEn = "Uranium triplatinum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ultimet_dust",
                NameRu = "Ультимет (Пыль)",
                NameEn = "Ultimet (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "naquadria_sulfate_dust",
                NameRu = "Сульфат наквадрии (Пыль)",
                NameEn = "Naquadria sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "barium_dust",
                NameRu = "Барий (Пыль)",
                NameEn = "Barium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "chromium_trioxide_dust",
                NameRu = "Триоксид хрома (Пыль)",
                NameEn = "Chromium trioxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hssg_dust",
                NameRu = "HSS-G (Пыль)",
                NameEn = "HSS-G (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "desh_dust",
                NameRu = "Деш (Пыль)",
                NameEn = "desh (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rad_away_dust",
                NameRu = "Антирадин (Пыль)",
                NameEn = "Rad away (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungsten_carbide_dust",
                NameRu = "Карбид вольфрама (Пыль)",
                NameEn = "Tungsten carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "platinum_group_sludge_dust",
                NameRu = "Шлам платиновой группы",
                NameEn = "Platinum group sludge",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "aluminium_sulfite_dust",
                NameRu = "Сульфат алюминия (Пыль)",
                NameEn = "Aluminium sulfite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "paper_dust",
                NameRu = "Целлюлоза",
                NameEn = "Paper (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "trinium_dust",
                NameRu = "Триниум (Пыль)",
                NameEn = "Trinium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "brick_dust",
                NameRu = "Кирпич (Пыль)",
                NameEn = "Brick (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "obsidian_dust",
                NameRu = "Обсидиан (Пыль)",
                NameEn = "Obsidian (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "neptunium_237_dust",
                NameRu = "Нептуний 237 (Пыль)",
                NameEn = "Neptunium 237 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "molybdenite_dust",
                NameRu = "Молибденит (Пыль)",
                NameEn = "Molybdenite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rhodium_plated_palladium_dust",
                NameRu = "Палладий с родиевым покрытием (Пыль)",
                NameEn = "Rhodium plated palladium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "chromium_dust",
                NameRu = "Хром (Пыль)",
                NameEn = "Chromium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cerium_dust",
                NameRu = "Церий (Пыль)",
                NameEn = "Cerium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ostrum_iodide_dust",
                NameRu = "Йодид острума (Пыль)",
                NameEn = "ostrum_iodide_dust (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gypsum_dust",
                NameRu = "Гипс (Пыль)",
                NameEn = "Gypsum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "concrete_dust",
                NameRu = "Бетон (Пыль)",
                NameEn = "Concrete (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "nether_star_dust",
                NameRu = "Звезда незера (Пыль)",
                NameEn = "Nether star (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "nickel_zinc_ferrite_dust",
                NameRu = "Никель цинк феррит (Пыль)",
                NameEn = "Nickel zinc ferrite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "borax_dust",
                NameRu = "Бура (Пыль)",
                NameEn = "Borax (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lapis_dust",
                NameRu = "Лазуритит (Пыль)",
                NameEn = "Lapis (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hardwood_dust",
                NameRu = "Масса из твёрдого дерева",
                NameEn = "Hardwood dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "yellow_limonite_dust",
                NameRu = "Лимонит (Пыль)",
                NameEn = "Limonite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "silicon_dioxide_dust",
                NameRu = "Диоксид кремния (Пыль)",
                NameEn = "Silicon dioxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "apatite_dust",
                NameRu = "Апатит (Пыль)",
                NameEn = "Apatite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "asbestos_dust",
                NameRu = "Асбест (Пыль)",
                NameEn = "Asbestos (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "titanium_carbide_dust",
                NameRu = "Карбид титана (Пыль)",
                NameEn = "Titanium carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bastnasite_dust",
                NameRu = "Бастнезит (Пыль)",
                NameEn = "Bastnasite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pollucite_dust",
                NameRu = "Поллуцит (Пыль)",
                NameEn = "Pollucite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "samarium_dust",
                NameRu = "Самарий (Пыль)",
                NameEn = "Samarium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_bisulfate_dust",
                NameRu = "Бисульфат натрия (Пыль)",
                NameEn = "Sodium bisulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zincite_dust",
                NameRu = "Цинкит (Пыль)",
                NameEn = "Zincite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "stainless_steel_dust",
                NameRu = "Нержавеющая сталь (Пыль)",
                NameEn = "Stainless steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bismuth_dust",
                NameRu = "Висмут (Пыль)",
                NameEn = "Bismuth (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "carbon_dust",
                NameRu = "Углерод (Пыль)",
                NameEn = "Carbon (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_dust",
                NameRu = "Натрий (Пыль)",
                NameEn = "Sodium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bronze_dust",
                NameRu = "Бронза (Пыль)",
                NameEn = "Bronze (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cupric_oxide_dust",
                NameRu = "Оксид меди (Пыль)",
                NameEn = "Cupric oxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "iridium_chloride_dust",
                NameRu = "Хлорид иридия (Пыль)",
                NameEn = "Iridium chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ruthenium_trinium_americium_neutronate_dust",
                NameRu = "Нейтронат рутения триния америция (Пыль)",
                NameEn = "Ruthenium trinium americium neutronate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "thorium_dust",
                NameRu = "Торианит (Пыль)",
                NameEn = "Thorium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tricalcium_phosphate_dust",
                NameRu = "Трикальцийфосфат (Пыль)",
                NameEn = "Tricalcium phosphate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "incoloy_ma_956_dust",
                NameRu = "Инколой MA-956 (Пыль)",
                NameEn = "Incoloy MA-956 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cinnabar_dust",
                NameRu = "Киноварь (Пыль)",
                NameEn = "Cinnabar (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "brass_dust",
                NameRu = "Латунь (Пыль)",
                NameEn = "Brass (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "nether_quartz_dust",
                NameRu = "Незер-кварц (Пыль)",
                NameEn = "nether_quartz_dust (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pyrolusite_dust",
                NameRu = "Пиролюзит (Пыль)",
                NameEn = "Pyrolusite_ (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rtm_alloy_dust",
                NameRu = "РВМ сплав (Пыль)",
                NameEn = "RTM alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bentonite_dust",
                NameRu = "Бентонит (Пыль)",
                NameEn = "Bentonite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "redrock_dust",
                NameRu = "Красная скала (Пыль)",
                NameEn = "Redrock (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "topaz_dust",
                NameRu = "Топаз (Пыль)",
                NameEn = "Topaz (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "diethylenetriaminepentaacetic_acid_dust",
                NameRu = "Диэтилентриаминпентауксусная кислота (Пыль)",
                NameEn = "Diethylenetriaminepentaacetic acid (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cobalt_brass_dust",
                NameRu = "Кобальтовая латунь (Пыль)",
                NameEn = "Cobalt brass (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "neodymium_dust",
                NameRu = "Неодим (Пыль)",
                NameEn = "Neodymium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "silicone_rubber_dust",
                NameRu = "Силиконовая резина (Пыль)",
                NameEn = "Silicone rubber (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "biphenyl_dust",
                NameRu = "Дифенил (Пыль)",
                NameEn = "Biphenyl (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rubber_dust",
                NameRu = "Резина (Пыль)",
                NameEn = "Rubber (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungstate_dust",
                NameRu = "Вольфрамат (Пыль)",
                NameEn = "Tungstate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "black_steel_dust",
                NameRu = "Черная сталь (Пыль)",
                NameEn = "Black steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rarest_metal_mixture_dust",
                NameRu = "Смесь редких металлов",
                NameEn = "Rarest metal mixture (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "black_bronze_dust",
                NameRu = "Черная бронза (Пыль)",
                NameEn = "Black bronze (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zeron_100_dust",
                NameRu = "Зерон-100 (Пыль)",
                NameEn = "Zeron-100 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnetic_samarium_dust",
                NameRu = "Магнитный самарий (Пыль)",
                NameEn = "Magnetic samarium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "samarium_iron_arsenic_oxide_dust",
                NameRu = "Оксид самария железа мышьяка (Пыль)",
                NameEn = "Samarium iron arsenic oxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "blue_steel_dust",
                NameRu = "Синяя сталь (Пыль)",
                NameEn = "Blue steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ammonium_chloride_dust",
                NameRu = "Хлорид аммония (Пыль)",
                NameEn = "Ammonium chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_bicarbonate_dust",
                NameRu = "Натрия бикарбонат (Пыль)",
                NameEn = "Sodium bicarbonate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "granitic_mineral_sand_dust",
                NameRu = "Гранитный минеральный песок (Пыль)",
                NameEn = "Granitic mineral sand (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "manganese_phosphide_dust",
                NameRu = "Фосфид марганца (Пыль)",
                NameEn = "Manganese phosphide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rock_salt_dust",
                NameRu = "Каменная соль (Пыль)",
                NameEn = "Rock salt (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "stellite_100_dust",
                NameRu = "Стеллит (Пыль)",
                NameEn = "Stellite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "naquadria_dust",
                NameRu = "Наквадрия (Пыль)",
                NameEn = "Naquadria (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "indium_phosphide_dust",
                NameRu = "Фосфид индия (Пыль)",
                NameEn = "Indium phosphide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "epoxy_dust",
                NameRu = "Эпоксидная смола (Пыль)",
                NameEn = "Epoxy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "caesium_137_dust",
                NameRu = "Цезий 137 (Пыль)",
                NameEn = "Caesium 137 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_sulfate_dust",
                NameRu = "Сульфат калия (Пыль)",
                NameEn = "Potassium sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnetic_neodymium_dust",
                NameRu = "Магнитный неодим (Пыль)",
                NameEn = "Magnetic neodymium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_hydroxide_dust",
                NameRu = "Гидроксид натрия (Пыль)",
                NameEn = "Sodium hydroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "nichrome_dust",
                NameRu = "Нихром (Пыль)",
                NameEn = "Nichrome (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pyrope_dust",
                NameRu = "Пироп (Пыль)",
                NameEn = "Pyrope (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lepidolite_dust",
                NameRu = "Лепидолит (Пыль)",
                NameEn = "Lepidolite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "goethite_dust",
                NameRu = "Гётит (Пыль)",
                NameEn = "Goethite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "americium_dust",
                NameRu = "Америций 241 (Пыль)",
                NameEn = "Americium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "europium_dust",
                NameRu = "Европий (Пыль)",
                NameEn = "Europium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "thorium_230_dust",
                NameRu = "Торий 230 (Пыль)",
                NameEn = "Thorium 230 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ilmenite_slag_dust",
                NameRu = "Ильменитовый шлак (Пыль)",
                NameEn = "Ilmenite slag (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "coke_dust",
                NameRu = "Коксовый уголь (Пыль)",
                NameEn = "Coke (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "chalcocite_dust",
                NameRu = "Халькозин (Пыль)",
                NameEn = "Chalcocite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "enriched_naquadah_sulfate_dust",
                NameRu = "Обогащенный сульфат наквады (Пыль)",
                NameEn = "Enriched naquadah sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tarkianite_dust",
                NameRu = "Таркианит (Пыль)",
                NameEn = "Tarkianite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "uvarovite_dust",
                NameRu = "Уваровит (Пыль)",
                NameEn = "Uvarovite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "vanadium_gallium_dust",
                NameRu = "Ванадий-Галлий (Пыль)",
                NameEn = "Vanadium gallium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungsten_dust",
                NameRu = "Вольфрам (Пыль)",
                NameEn = "Tungsten (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "realgar_dust",
                NameRu = "Реальгар (Пыль)",
                NameEn = "Realgar (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "glass_dust",
                NameRu = "Стекло (Пыль)",
                NameEn = "Glass (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ferrite_mixture_dust",
                NameRu = "Ферритовая смесь (Пыль)",
                NameEn = "Ferrite mixture (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcium_dust",
                NameRu = "Кальций (Пыль)",
                NameEn = "Calcium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_nitrate_dust",
                NameRu = "Нитрат натрия (Пыль)",
                NameEn = "Sodium nitrate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "paracetamol_dust",
                NameRu = "Парацетамол (Пыль)",
                NameEn = "Paracetamol (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "plutonium_dust",
                NameRu = "Плутоний 239 (Пыль)",
                NameEn = "Plutonium 239 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "styrene_butadiene_rubber_dust",
                NameRu = "Стирол-бутадиеновая резина (Пыль)",
                NameEn = "Styrene butadiene rubber (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "crimsite_dust",
                NameRu = "Кримит (Пыль)",
                NameEn = "Crimsite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "vanadium_steel_dust",
                NameRu = "Ванадиевая сталь (Пыль)",
                NameEn = "Vanadium steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "inert_metal_mixture_dust",
                NameRu = "Смесь инертных металлов",
                NameEn = "Inert metal mixture (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "caprolactam_dust",
                NameRu = "Капролактам (Пыль)",
                NameEn = "Caprolactam (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pentlandite_dust",
                NameRu = "Пентландит (Пыль)",
                NameEn = "Pentlandite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "saltpeter_dust",
                NameRu = "Селитра (Пыль)",
                NameEn = "Saltpeter (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "antimony_trioxide_dust",
                NameRu = "Триоксид сурьмы (Пыль)",
                NameEn = "Antimony trioxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zinc_sulfide_dust",
                NameRu = "Сульфид цинка (Пыль)",
                NameEn = "zinc sulfide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hematite_dust",
                NameRu = "Гематит (Пыль)",
                NameEn = "Hematite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungsten_steel_dust",
                NameRu = "Вольфрамовая сталь (Пыль)",
                NameEn = "Tungsten steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "monazite_dust",
                NameRu = "Монацит (Пыль)",
                NameEn = "Monazite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "alunite_dust",
                NameRu = "Алунит (Пыль)",
                NameEn = "Alunite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnalium_dust",
                NameRu = "Магналий (Пыль)",
                NameEn = "Magnalium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polybenzimidazole_dust",
                NameRu = "Полибензимидазол (ПБИ) (Пыль)",
                NameEn = "Polybenzimidazole (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "iridium_dust",
                NameRu = "Иридий (Пыль)",
                NameEn = "Iridium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "palladium_raw_dust",
                NameRu = "Необработанный порошок палладия",
                NameEn = "Palladium raw dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cyclohexanone_oxime_dust",
                NameRu = "Циклогексаноноксим (Пыль)",
                NameEn = "Cyclohexanone oxime (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_carbonate_dust",
                NameRu = "Карбонат калия (Пыль)",
                NameEn = "Potassium carbonate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ilmenite_dust",
                NameRu = "Ильменит (Пыль)",
                NameEn = "Ilmenite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "iridium_metal_residue_dust",
                NameRu = "Металлический остаток иридия",
                NameEn = "Iridium metal residue (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cassiterite_sand_dust",
                NameRu = "Касситеритовый песок",
                NameEn = "Cassiterite sand",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "red_steel_dust",
                NameRu = "Красная сталь (Пыль)",
                NameEn = "Red steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polyethylene_dust",
                NameRu = "Полиэтилен (Пыль)",
                NameEn = "Polyethylene (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnetic_steel_dust",
                NameRu = "Магнитная сталь (Пыль)",
                NameEn = "Magnetic steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "indium_gallium_phosphide_dust",
                NameRu = "Индий галлий фосфид (Пыль)",
                NameEn = "Indium gallium phosphide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "treated_wood_dust",
                NameRu = "Кучка обработанной древесной массы",
                NameEn = "Treated wood (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "boron_dust",
                NameRu = "Бор (Пыль)",
                NameEn = "Boron (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "perlite_dust",
                NameRu = "Перлит (Пыль)",
                NameEn = "Perlite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "indium_dust",
                NameRu = "Индий (Пыль)",
                NameEn = "Indium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pyrite_dust",
                NameRu = "Пирит (Пыль)",
                NameEn = "Pyrite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "barium_sulfide_dust",
                NameRu = "Сульфид бария (Пыль)",
                NameEn = "Barium sulfide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "andradite_dust",
                NameRu = "Андрадит (Пыль)",
                NameEn = "Andradite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ruridit_dust",
                NameRu = "Руридит (Пыль)",
                NameEn = "Ruridit (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lutetium_dust",
                NameRu = "Лютеций (Пыль)",
                NameEn = "Lutetium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "osmium_dust",
                NameRu = "Осмий (Пыль)",
                NameEn = "Osmium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hastelloy_c_276_dust",
                NameRu = "Хастеллой-C276 (Пыль)",
                NameEn = "Hastelloy-C276 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "massicot_dust",
                NameRu = "Массикот (Пыль)",
                NameEn = "Massicot (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "molybdenum_disilicide_dust",
                NameRu = "Дисилицид молибдена (Пыль)",
                NameEn = "molybdenum disilicide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potash_dust",
                NameRu = "Оксид калия (Пыль)",
                NameEn = "Potash (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_feldspar_dust",
                NameRu = "Калиевый полевой шпат (Пыль)",
                NameEn = "Potassium feldspar (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "grossular_dust",
                NameRu = "Гроссуляр (Пыль)",
                NameEn = "Grossular (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rose_gold_dust",
                NameRu = "Розовое золото (Пыль)",
                NameEn = "Rose gold (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "malachite_dust",
                NameRu = "Малахит (Пыль)",
                NameEn = "Malachite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "iodine_dust",
                NameRu = "Иод (Пыль)",
                NameEn = "Iodine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "electrum_dust",
                NameRu = "Электрум (Пыль)",
                NameEn = "Electrum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "collagen_dust",
                NameRu = "Коллаген (Пыль)",
                NameEn = "Collagen (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "thallium_dust",
                NameRu = "Таллий (Пыль)",
                NameEn = "Thallium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tantalum_dust",
                NameRu = "Тантал (Пыль)",
                NameEn = "Tantalum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polydimethylsiloxane_dust",
                NameRu = "Полидиметилсилоксан (Пыль)",
                NameEn = "polydimethylsiloxane (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "basaltic_mineral_sand_dust",
                NameRu = "Базальтовый минеральный песок (Пыль)",
                NameEn = "Basaltic mineral sand (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lapotron_dust",
                NameRu = "Лапотрон (Пыль)",
                NameEn = "Lapotron (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "charcoal_dust",
                NameRu = "Древесный уголь (Пыль)",
                NameEn = "Charcoal (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "flint_dust",
                NameRu = "Кремень (Пыль)",
                NameEn = "Flint (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polyvinyl_chloride_dust",
                NameRu = "Поливинил хлорид (Пыль)",
                NameEn = "Polyvinyl chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cooperite_dust",
                NameRu = "Куперит (Пыль)",
                NameEn = "Cooperite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesium_diboride_dust",
                NameRu = "Диборид магния (Пыль)",
                NameEn = "Magnesium diboride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sterling_silver_dust",
                NameRu = "Стерлинговое серебро (Пыль)",
                NameEn = "Sterling silver (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pitchblende_dust",
                NameRu = "Уранит (Пыль)",
                NameEn = "Pitchblende (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcium_chloride_dust",
                NameRu = "Хлорид кальция (Пыль)",
                NameEn = "Calcium chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "trinium_sulfide_dust",
                NameRu = "Сульфид триния (Пыль)",
                NameEn = "Trinium sulfide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "wrought_iron_dust",
                NameRu = "Кованное железо (Пыль)",
                NameEn = "Wrought iron (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnetite_dust",
                NameRu = "Магнетит (Пыль)",
                NameEn = "Magnetite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tantalum_carbide_dust",
                NameRu = "Карбид тантала (Пыль)",
                NameEn = "Tantalum carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polytetrafluoroethylene_dust",
                NameRu = "Политетрафторэтилен (Пыль)",
                NameEn = "Polytetrafluoroethylene (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "niobium_dust",
                NameRu = "Ниобий (Пыль)",
                NameEn = "Niobium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gallium_arsenide_dust",
                NameRu = "Арсенид галлия (Пыль)",
                NameEn = "Gallium arsenide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "kanthal_dust",
                NameRu = "Кантал (Пыль)",
                NameEn = "Kanthal (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "opal_dust",
                NameRu = "Опал (Пыль)",
                NameEn = "Opal (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungstic_acid_dust",
                NameRu = "Вольфрамовая кислота (Пыль)",
                NameEn = "tungstic_acid_dust (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cadmium_dust",
                NameRu = "Кадмий (Пыль)",
                NameEn = "Cadmium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcium_phosphide_dust",
                NameRu = "Фосфид кальция (Пыль)",
                NameEn = "Calcium phosphide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "glauconite_sand_dust",
                NameRu = "Глауконитовый песок (Пыль)",
                NameEn = "Glauconite sand (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "activated_carbon_dust",
                NameRu = "Активированный уголь (Пыль)",
                NameEn = "Activated carbon (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gold_dust",
                NameRu = "Золото (Пыль)",
                NameEn = "Gold (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "vanadium_dust",
                NameRu = "Ванадий (Пыль)",
                NameEn = "Vanadium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_ferrocyanide_dust",
                NameRu = "Ферроцианид калия (Пыль)",
                NameEn = "Potassium ferrocyanide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "blue_topaz_dust",
                NameRu = "Синий топаз (Пыль)",
                NameEn = "Blue topaz (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lithium_dust",
                NameRu = "Литий (Пыль)",
                NameEn = "Lithium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "vitrified_asbestos_dust",
                NameRu = "Остеклованный асбест (Пыль)",
                NameEn = "Vitrified asbestos (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "caesium_dust",
                NameRu = "Цезий (Пыль)",
                NameEn = "Caesium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "uranium_rhodium_dinaquadide_dust",
                NameRu = "Уран родий динаквада (Пыль)",
                NameEn = "Uranium rhodium dinaquadide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "garnierite_dust",
                NameRu = "Гарниерит (Пыль)",
                NameEn = "Garnierite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "antimony_dust",
                NameRu = "Сурьма (Пыль)",
                NameEn = "Antimony (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "spessartine_dust",
                NameRu = "Спасерит (Пыль)",
                NameEn = "Spessartine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "yttrium_barium_cuprate_dust",
                NameRu = "Оксид иттрия-бария-меди (Пыль)",
                NameEn = "Yttrium barium cuprate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "mica_dust",
                NameRu = "Слюда (Пыль)",
                NameEn = "Mica (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "stibnite_dust",
                NameRu = "Стибнит (Пыль)",
                NameEn = "Stibnite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "wax_dust",
                NameRu = "Воск (Пыль)",
                NameEn = "Wax (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "reinforced_epoxy_resin_dust",
                NameRu = "Укреплённая эпоксидная смола (Пыль)",
                NameEn = "Reinforced epoxy resin (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "maraging_steel_300_dust",
                NameRu = "Мартенситностареющая сталь 300 (Пыль)",
                NameEn = "Maraging steel 300 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "enriched_naquadah_trinium_europium_duranide_dust",
                NameRu = "Обогащенный наквада триний европий дюраний (Пыль)",
                NameEn = "Enriched naquadah trinium europium duranide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcium_hydroxide_dust",
                NameRu = "Гидроксид кальция (Пыль)",
                NameEn = "Calcium hydroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "red_garnet_dust",
                NameRu = "Красный гранат (Пыль)",
                NameEn = "Red garnet (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "coal_dust",
                NameRu = "Уголь (Пыль)",
                NameEn = "Coal (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_sulfide_dust",
                NameRu = "Сульфид натрия (Пыль)",
                NameEn = "Sodium sulfide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodalite_dust",
                NameRu = "Содалит (Пыль)",
                NameEn = "Sodalite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "palladium_dust",
                NameRu = "Палладий (Пыль)",
                NameEn = "Palladium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "graphene_dust",
                NameRu = "Графен (Пыль)",
                NameEn = "Graphene (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "beryllium_dust",
                NameRu = "Бериллий (Пыль)",
                NameEn = "Beryllium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "kyanite_dust",
                NameRu = "Ционит (Пыль)",
                NameEn = "Kyanite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_hydroxide_dust",
                NameRu = "Гидроксид калия (Пыль)",
                NameEn = "Potassium hydroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rutile_dust",
                NameRu = "Рутил (Пыль)",
                NameEn = "Rutile (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sapphire_dust",
                NameRu = "Сапфир (Пыль)",
                NameEn = "Sapphire (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "diamond_dust",
                NameRu = "Алмаз (Пыль)",
                NameEn = "Diamond (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "platinum_raw_dust",
                NameRu = "Необработанный платиновый порошок",
                NameEn = "Platinum raw dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "blue_alloy_dust",
                NameRu = "Синий сплав (Пыль)",
                NameEn = "Blue alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "hsse_dust",
                NameRu = "HSS-E (Пыль)",
                NameEn = "HSS-E (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calcium_carbonate_dust",
                NameRu = "Карбонат кальция (Пыль)",
                NameEn = "Calcium carbonate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "mercury_barium_calcium_cuprate_dust",
                NameRu = "Купрат ртути бария кальция (Пыль)",
                NameEn = "Mercury barium calcium cuprate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "meat_dust",
                NameRu = "Мясной фарш",
                NameEn = "Meat dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "oilsands_dust",
                NameRu = "Нефтеносный песок (Пыль)",
                NameEn = "Oilsand (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "chalcopyrite_dust",
                NameRu = "Халькопирит (Пыль)",
                NameEn = "Chalcopyrite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bismuth_bronze_dust",
                NameRu = "Висмутовая бронза (Пыль)",
                NameEn = "Bismuth bronze (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "garnet_sand_dust",
                NameRu = "Гранатовый песок (Пыль)",
                NameEn = "Garnet sand (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "copper_dust",
                NameRu = "Медь (Пыль)",
                NameEn = "Copper (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "arsenic_dust",
                NameRu = "Мышьяк (Пыль)",
                NameEn = "Arsenic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "silicon_dust",
                NameRu = "Кремний (Пыль)",
                NameEn = "Silicon (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sphalerite_dust",
                NameRu = "Сфалерит (Пыль)",
                NameEn = "Sphalerite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rocket_alloy_t2_dust",
                NameRu = "ASM 4914 титановый ракетный сплав (Пыль)",
                NameEn = "Rocket alloy t2 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "naquadah_alloy_dust",
                NameRu = "Сплав наквада (Пыль)",
                NameEn = "Naquadah alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "darmstadtium_dust",
                NameRu = "Дармштадтий (Пыль)",
                NameEn = "Darmstadtium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "soldering_alloy_dust",
                NameRu = "Припой (Пыль)",
                NameEn = "Soldering alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesium_chloride_dust",
                NameRu = "Хлорид магния (Пыль)",
                NameEn = "Magnesium chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gallium_sulfide_dust",
                NameRu = "Сульфид галлия (Пыль)",
                NameEn = "Gallium sulfide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "stone_dust",
                NameRu = "Камень (Пыль)",
                NameEn = "Stone (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "battery_alloy_dust",
                NameRu = "Аккумуляторный сплав (Пыль)",
                NameEn = "Battery alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "quartz_sand_dust",
                NameRu = "Кварцевый песок (Пыль)",
                NameEn = "Quartz sand (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ochrum_dust",
                NameRu = "Охрум (Пыль)",
                NameEn = "Ochrum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "naquadah_dust",
                NameRu = "Наквада (Пыль)",
                NameEn = "Naquadah (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "annealed_copper_dust",
                NameRu = "Отожженная медь (Пыль)",
                NameEn = "Annealed copper (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rare_earth_dust",
                NameRu = "Редкоземельные элементы",
                NameEn = "Rare earth (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lazurite_dust",
                NameRu = "Лазурит (Пыль)",
                NameEn = "Lazurite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "gelatin_dust",
                NameRu = "Желатин (Пыль)",
                NameEn = "Gelatin (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "talc_dust",
                NameRu = "Тальк (Пыль)",
                NameEn = "Talc (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "indium_tin_barium_titanium_cuprate_dust",
                NameRu = "Купрат индия олова бария титана (Пыль)",
                NameEn = "Indium tin barium titanium cuprate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ruby_dust",
                NameRu = "Рубин (Пыль)",
                NameEn = "Ruby (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "amethyst_dust",
                NameRu = "Аметист (Пыль)",
                NameEn = "Amethyst (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cobalt_oxide_dust",
                NameRu = "Оксид кобальта (Пыль)",
                NameEn = "Cobalt oxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ostrum_dust",
                NameRu = "Острум (Пыль)",
                NameEn = "Ostrum (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "yttrium_dust",
                NameRu = "Иттрий (Пыль)",
                NameEn = "Yttrium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "graphite_dust",
                NameRu = "Графит (Пыль)",
                NameEn = "Graphite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cocoa_dust",
                NameRu = "Какао (Пыль)",
                NameEn = "Cocoa (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lead_dust",
                NameRu = "Свинец (Пыль)",
                NameEn = "Lead (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tin_alloy_dust",
                NameRu = "Оловянный сплав (Пыль)",
                NameEn = "Tin alloy (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "steel_dust",
                NameRu = "Сталь (Пыль)",
                NameEn = "Steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potassium_iodide_dust",
                NameRu = "Йодистый калий (Пыль)",
                NameEn = "Potassium iodide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "biotite_dust",
                NameRu = "Биотит (Пыль)",
                NameEn = "Biotite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tantalite_dust",
                NameRu = "Танталит (Пыль)",
                NameEn = "Tantalite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "aluminium_silicate_dust",
                NameRu = "Алюмосиликат (Пыль)",
                NameEn = "Aluminium silicate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tritanium_dust",
                NameRu = "Тританий (Пыль)",
                NameEn = "Tritanium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lactose_dust",
                NameRu = "Лактоза (Пыль)",
                NameEn = "Lactose (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lithium_chloride_dust",
                NameRu = "Хлорид лития (Пыль)",
                NameEn = "Lithium chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "phosphorus_dust",
                NameRu = "Фосфор (Пыль)",
                NameEn = "Phosphorus (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "potin_dust",
                NameRu = "Потин (Пыль)",
                NameEn = "Potin (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "electrotine_dust",
                NameRu = "Электротин (Пыль)",
                NameEn = "Electrotine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "veridium_dust",
                NameRu = "Веридий (Пыль)",
                NameEn = "Veridium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sorbitol_dust",
                NameRu = "Сорбитол (Пыль)",
                NameEn = "Sorbitol (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungsten_oxide_dust",
                NameRu = "Оксид вольфрама (Пыль)",
                NameEn = "Tungsten oxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "thallium_sulfate_dust",
                NameRu = "Сульфат таллия (Пыль)",
                NameEn = "Thallium sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesia_refractory_brick_dust",
                NameRu = "Склеенный смолой магнезиальный огнеупорный кирпич (Пыль)",
                NameEn = "Magnesia refractory brick (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "refined_nuclear_residue_dust",
                NameRu = "Переработанные ядерные отходы (Пыль)",
                NameEn = "Refined nuclear residue (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "methylene_diphenyl_diisocyanate_dust",
                NameRu = "Метилен дифелин-4,4'-диизоционат (Пыль)",
                NameEn = "Methylene diphenyl diisocyanate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rough_silicon_carbide_dust",
                NameRu = "Необработанный карбид кремния (Пыль)",
                NameEn = "Rough silicon carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "lorandite_dust",
                NameRu = "Лорандит (Пыль)",
                NameEn = "Lorandite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_hydride_dust",
                NameRu = "Гидрид натрия (Пыль)",
                NameEn = "Sodium hydride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "boron_10_hydroxide_dust",
                NameRu = "Гидроксид бора-10 (Пыль)",
                NameEn = "Boron-10 hydroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cassiterite_regolith_dust",
                NameRu = "Кассеритовый реголит (Пыль)",
                NameEn = "Cassiterite regolith (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "boron_carbide_dust",
                NameRu = "Карбид бора (Пыль)",
                NameEn = "Boron carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "weak_red_steel_dust",
                NameRu = "Сырая красная сталь (Пыль)",
                NameEn = "Weak red steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "oxidized_nuclear_residue_dust",
                NameRu = "Окисленные ядерные отходы (Пыль)",
                NameEn = "oxidized nuclear residue (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "igneous_intermediate_dust",
                NameRu = "Средняя магматическая порода (Пыль)",
                NameEn = "Igneous intermediate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tin_chloride_dust",
                NameRu = "Двуххлористое олово (Пыль)",
                NameEn = "Tin chloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bright_regolith_dust",
                NameRu = "Яркий реголит (Пыль)",
                NameEn = "Bright regolith (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "clean_powder_dust",
                NameRu = "Силикатированный очищенный рениумный порошок (Пыль)",
                NameEn = "Clean powder (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_deuteroxide_dust",
                NameRu = "Дейтерооксид натрия (Пыль)",
                NameEn = "Sodium deuteroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "redstone_nitrate_dust",
                NameRu = "Нитрат редстоуна (Пыль)",
                NameEn = "Redstone nitrate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "magnesium_hydroxide_dust",
                NameRu = "Гидроксид магния (Пыль)",
                NameEn = "Magnesium hydroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "vitrified_pearl_dust",
                NameRu = "Остеклованный эндер (Пыль)",
                NameEn = "Vitrified pearl (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "metamorphic_dust",
                NameRu = "Метаморфическая порода (Пыль)",
                NameEn = "Metamorphic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "mycelienzene_dust",
                NameRu = "Мицезоллий (Пыль)",
                NameEn = "Mycelienzene (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "weak_blue_steel_dust",
                NameRu = "Сырая синяя сталь (Пыль)",
                NameEn = "Weak blue steel (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "weak_mo_si_b_dust",
                NameRu = "Слабый Mo-Si-B (Пыль)",
                NameEn = "Weak Mo-Si-B (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_fluorine_dust",
                NameRu = "Фтористый натрий (Пыль)",
                NameEn = "Sodium fluorine (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "aes_mix_dust",
                NameRu = "Щелочноземельный силикат (Пыль)",
                NameEn = "Aes mix (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "alumina_dust",
                NameRu = "Оксид алюминия (Пыль)",
                NameEn = "Alumina (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bi_pb_sn_cd_in_tl_dust",
                NameRu = "Bi-Pb-Cn-Cd-In-Tl (Пыль)",
                NameEn = "Bi-Pb-Cn-Cd-In-Tl (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "boric_acid_dust",
                NameRu = "Борная кислота (Пыль)",
                NameEn = "Boric acid (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "apt_dust",
                NameRu = "Паравольфрамат аммония (Пыль)",
                NameEn = "Apt (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_sulfate_dust",
                NameRu = "Сульфат натрия (Пыль)",
                NameEn = "Sodium sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "silicon_carbide_dust",
                NameRu = "Карбид кремния (Пыль)",
                NameEn = "Silicon carbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "recovered_ionic_complex_dust",
                NameRu = "Восстановленный ионный комплекс (Пыль)",
                NameEn = "Recovered ionic complex (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "aluminium_sulfate_dust",
                NameRu = "Сульфат алюминия (Пыль)",
                NameEn = "Aluminium sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "inconel_718_dust",
                NameRu = "Инконель-718 (Пыль)",
                NameEn = "Inconel-718 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zirconium_tetrachloride_dust",
                NameRu = "Тетрахлорид циркония (Пыль)",
                NameEn = "Zirconium tetrachloride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "polysilicon_dust",
                NameRu = "Поликремний (Пыль)",
                NameEn = "Polysilicon (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "copper_trace_catalyst_dust",
                NameRu = "Следовая каталитическая медь (Пыль)",
                NameEn = "Copper trace catalyst (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "nuclear_residue_dust",
                NameRu = "Ядерные отходы (Пыль)",
                NameEn = "Nuclear residue (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "citric_acid_dust",
                NameRu = "Лимонная кислота (Пыль)",
                NameEn = "Citric acid (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "igneous_felsic_dust",
                NameRu = "Кислая магматическая порода (Пыль)",
                NameEn = "Igneous felsic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "bakelite_dust",
                NameRu = "Бакелит (Пыль)",
                NameEn = "Bakelite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ammonium_tungstate_dust",
                NameRu = "Вольфрамат аммония (Пыль)",
                NameEn = "Ammonium tungstate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ammonia_borane_dust",
                NameRu = "Боразан (Пыль)",
                NameEn = "Ammonia borane (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "mo_50_re_dust",
                NameRu = "Mo-50 Re (Пыль)",
                NameEn = "Mo-50 Re (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "inert_dust_fraction_dust",
                NameRu = "Инертная фракция (Пыль)",
                NameEn = "Inert fraction (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "weak_inconel_718_dust",
                NameRu = "Слабый инконель-718 (Пыль)",
                NameEn = "Weak inconel-718 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "regolith_mush_dust",
                NameRu = "Реголитовая каша (Пыль)",
                NameEn = "Regolith mush (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "mo_si_b_dust",
                NameRu = "Mo-Si-B (Пыль)",
                NameEn = "Mo-Si-B (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_nitrate_dust",
                NameRu = "Нитрат натрия (Пыль)",
                NameEn = "Sodium nitrate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "goethe_regolith_dust",
                NameRu = "Гётитовый реголит (Пыль)",
                NameEn = "Goethe regolith (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "cholesterol_dust",
                NameRu = "Холестерин (Пыль)",
                NameEn = "Cholesterol (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "crimsene_dust",
                NameRu = "Багреллий (Пыль)",
                NameEn = "Crimsene (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "dirty_mo_si_b_dust",
                NameRu = "Грязный сплав Mo-Si-B (Пыль)",
                NameEn = "Dirty Mo-Si-B (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "calorite_dust",
                NameRu = "Калорит (Пыль)",
                NameEn = "Calorite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zinc_sulfate_dust",
                NameRu = "Сульфат цинка (Пыль)",
                NameEn = "Zinc sulfate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_borohydride_dust",
                NameRu = "Боргидрит натрия (Пыль)",
                NameEn = "Sodium borohydride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_tungstate_dust",
                NameRu = "Вольфрамат натрия (Пыль)",
                NameEn = "Sodium tungstate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "glucose_dust",
                NameRu = "Глюкоза (Пыль)",
                NameEn = "Glucose (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "pyrogallol_dust",
                NameRu = "Пирогаллол (Пыль)",
                NameEn = "Pyrogallol (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "certus_regolith_dust",
                NameRu = "Кварцевый реголит (Пыль)",
                NameEn = "Certus regolith (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "fructose_dust",
                NameRu = "Фруктоза (Пыль)",
                NameEn = "Fructose (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "igneous_ultramafic_dust",
                NameRu = "Ультраосновная магматическая порода (Пыль)",
                NameEn = "Igneous ultramafic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "woods_metal_dust",
                NameRu = "Сплав Вуда (Пыль)",
                NameEn = "Woods metal (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "refractory_clay_dust",
                NameRu = "Огнеупорная глина (Пыль)",
                NameEn = "Refractory clay (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "aluminium_hydroxide_dust",
                NameRu = "Гидроксид алюминия (Пыль)",
                NameEn = "Aluminium hydroxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tungsten_bismuth_oxide_composite_dust",
                NameRu = "Композит оксида-вольфрама-висмута (Пыль)",
                NameEn = "Tungsten bismuth oxide composite (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "warpane_dust",
                NameRu = "Искажеллий (Пыль)",
                NameEn = "Warpane (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "igneous_mafic_dust",
                NameRu = "Основная магматическая порода (Пыль)",
                NameEn = "Igneous mafic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "catalyser_powder_dust",
                NameRu = "Катализаторный рениумный порошок ZSM-5 (Пыль)",
                NameEn = "Catalyser powder (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "organic_stabilizer_dust",
                NameRu = "Органический стабилизатор (Пыль)",
                NameEn = "Organic stabilizer (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zircon_dust",
                NameRu = "Цирконий (Пыль)",
                NameEn = "Zircon (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rene_41_dust",
                NameRu = "Рене-41 (Пыль)",
                NameEn = "Rene 41 (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_aluminium_dust",
                NameRu = "Алюминат натрия (Пыль)",
                NameEn = "Sodium aluminium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sedimentary_carbonate_dust",
                NameRu = "Карбонатный осадок (Пыль)",
                NameEn = "Sedimentary carbonate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sedimentary_clastic_dust",
                NameRu = "Обломочный осадок (Пыль)",
                NameEn = "Sedimentary clastic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "trace_catalyst_salt_e_dust",
                NameRu = "Следовая каталитическая соль E (Пыль)",
                NameEn = "Trace catalyst salt E (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "tetrafluoroethane_dust",
                NameRu = "Тетрафторэтан (Пыль)",
                NameEn = "Tetrafluoroethane (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "14_sorbitan_dust",
                NameRu = "1,4-сорбитан (Пыль)",
                NameEn = "1,4-sorbitan (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "galactose_dust",
                NameRu = "Галактоза (Пыль)",
                NameEn = "Galactose (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_methoxide_dust",
                NameRu = "Метоксид натрия (Пыль)",
                NameEn = "Sodium methoxide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sodium_dihydrogen_citrate_dust",
                NameRu = "Цитрат натрия 2-замещённый (Пыль)",
                NameEn = "Sodium dihydrogen citrate (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zirconium_bromide_dust",
                NameRu = "Четырёхбромистый цирконий (Пыль)",
                NameEn = "Zirconium bromide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "isosorbide_dust",
                NameRu = "Изосорбид (Пыль)",
                NameEn = "Isosorbide (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "zirconium_diboride_dust",
                NameRu = "Диборид циркония (Пыль)",
                NameEn = "Zirconium diboride (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "certus_quartz_dust",
                NameRu = "Пыль истинного кварца",
                NameEn = "Certus quartz dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "fluix_dust",
                NameRu = "Флюисовая пыль",
                NameEn = "Fluix dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "ender_dust",
                NameRu = "Эндер-пыль",
                NameEn = "Ender dust",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "rose_quartz_dust",
                NameRu = "Розовый кварц (Пыль)",
                NameEn = "Rose quartz (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "etrium_dust",
                NameRu = "Этриум (Пыль)",
                NameEn = "Etrium (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            new GameItem
            {
                Id = "sedimentary_organic_dust",
                NameRu = "Органогенный осадок (Пыль)",
                NameEn = "Sedimentary organic (Dust)",
                Type = "Пыль",
                Tag = "#forge:dusts"
            },
            // ==========================================
            //                   СЛИТКИ
            // ==========================================
            new GameItem
            {
                Id = "iron_ingot",
                NameRu = "Серый чугун (Слиток)",
                NameEn = "Iron (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "pig_iron_ingot",
                NameRu = "Белый чугун (Слиток)",
                NameEn = "Pig iron (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "weak_steel_ingot",
                NameRu = "Сырая сталь (Слиток)",
                NameEn = "Weak steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "high_carbon_steel_ingot",
                NameRu = "Высокоуглеродистая сталь (Слиток)",
                NameEn = "High carbon steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "high_carbon_black_steel_ingot",
                NameRu = "Высокоуглеродистая сталь (Слиток)",
                NameEn = "High carbon black steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "high_carbon_blue_steel_ingot",
                NameRu = "Высокоуглеродистая сталь (Слиток)",
                NameEn = "High carbon blue steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "high_carbon_red_steel_ingot",
                NameRu = "Высокоуглеродистая сталь (Слиток)",
                NameEn = "High carbon red steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "activated_mo_si_b_ingot",
                NameRu = "Активированный сплав Mo-Si-B (Слиток)",
                NameEn = "Activated Mo-Si-B (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "homogenized_mo_si_b_ingot",
                NameRu = "Гомогенизированный сплав Mo-Si-B (Слиток)",
                NameEn = "Homogenized Mo-Si-B (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "homogenized_inconel_718_ingot",
                NameRu = "Гомогенизированный инконель-718 (Слиток)",
                NameEn = "Homogenized inconel-718 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "diamond_tipped_mo_50_re_ingot",
                NameRu = "Mo-50Re с алмазным напылением (Слиток)",
                NameEn = "Diamond tipped Mo-50Re (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "borosilicate_glass_ingot",
                NameRu = "Боросиликатное стекло (Слиток)",
                NameEn = "Borosilicate glass (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "stone_ingot",
                NameRu = "Камень (Слиток)",
                NameEn = "Stone (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polycaprolactam_ingot",
                NameRu = "Поликапролактам (Слиток)",
                NameEn = "Polycaprolactam (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "red_alloy_ingot",
                NameRu = "Красный сплав (Слиток)",
                NameEn = "Red alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "neutronium_ingot",
                NameRu = "Нейтроний (Слиток)",
                NameEn = "Neutronium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "uranium_ingot",
                NameRu = "Уран 238 (Слиток)",
                NameEn = "Uranium 238 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "plutonium_241_ingot",
                NameRu = "Плутоний-241 (Слиток)",
                NameEn = "Plutonium-241 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "platinum_ingot",
                NameRu = "Платина (Слиток)",
                NameEn = "Platinum (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "enriched_naquadah_ingot",
                NameRu = "Обогащённыя наквада (Слиток)",
                NameEn = "Enriched naquadah (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "aluminium_ingot",
                NameRu = "Алюминий (Слиток)",
                NameEn = "Aluminium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "ruthenium_ingot",
                NameRu = "Рутений (Слиток)",
                NameEn = "Ruthenium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnetic_iron_ingot",
                NameRu = "Магнитное железо (Слиток)",
                NameEn = "Magnetic iron (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "invar_ingot",
                NameRu = "Инвар (Слиток)",
                NameEn = "Invar (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "duranium_ingot",
                NameRu = "Дюраний (Слиток)",
                NameEn = "Duranium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "nickel_ingot",
                NameRu = "Никель (Слиток)",
                NameEn = "Nickel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "zinc_ingot",
                NameRu = "Цинк (Слиток)",
                NameEn = "Zinc (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "watertight_steel_ingot",
                NameRu = "Водостойкая сталь (Слиток)",
                NameEn = "Watertight steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "thorium_232_ingot",
                NameRu = "Торий 232 (Слиток)",
                NameEn = "Thorium 232 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "osmiridium_ingot",
                NameRu = "Осмистый иридий (Слиток)",
                NameEn = "Osmiridium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "cobalt_ingot",
                NameRu = "Кобальт (Слиток)",
                NameEn = "Cobalt (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "hsla_steel_ingot",
                NameRu = "HSLA сталь (Слиток)",
                NameEn = "HSLA steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "titanium_tungsten_carbide_ingot",
                NameRu = "Вольфрам-титанановый карбид (Слиток)",
                NameEn = "Titanium tungsten carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polyvinyl_butyral_ingot",
                NameRu = "Поливинилбутираль (Слиток)",
                NameEn = "Polyvinyl butyral (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "manganese_ingot",
                NameRu = "Марганец (Слиток)",
                NameEn = "Manganese (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "niobium_titanium_ingot",
                NameRu = "Ниобий-титан (Слиток)",
                NameEn = "Niobium titanium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "silver_ingot",
                NameRu = "Серебро (Слиток)",
                NameEn = "Silver (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rhodium_ingot",
                NameRu = "Родий (Слиток)",
                NameEn = "Rhodium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "hsss_ingot",
                NameRu = "HSS-S (Слиток)",
                NameEn = "HSS-S (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "molybdenum_ingot",
                NameRu = "Молибден (Слиток)",
                NameEn = "molybdenum (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polyphenylene_sulfide_ingot",
                NameRu = "Полифениленсульфид (Слиток)",
                NameEn = "Polyphenylene sulfide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tin_ingot",
                NameRu = "Олово (Слиток)",
                NameEn = "Tin (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rocket_alloy_t1_ingot",
                NameRu = "Красный алюминиево-стальной ракетный сплав (Слиток)",
                NameEn = "Rocket alloy t1 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "hastelloy_x_ingot",
                NameRu = "Хастеллой-X (Слиток)",
                NameEn = "Hastelloy-X (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "niobium_nitride_ingot",
                NameRu = "Нитрид ниобия (Слиток)",
                NameEn = "Niobium nitride (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "cupronickel_ingot",
                NameRu = "Купроникель (Слиток)",
                NameEn = "Cupronickel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "zirconium_ingot",
                NameRu = "Цирконий (Слиток)",
                NameEn = "Zirconium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "titanium_ingot",
                NameRu = "Титан (Слиток)",
                NameEn = "Titanium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "americium_ingot",
                NameRu = "Америций 243 (Слиток)",
                NameEn = "Americium 243 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "uranium_235_ingot",
                NameRu = "Уран-235 (Слиток)",
                NameEn = "Uranium-235 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "gallium_ingot",
                NameRu = "Галлий (Слиток)",
                NameEn = "Gallium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "californium_252_ingot",
                NameRu = "Калифорний 252 (Слиток)",
                NameEn = "Californium 252 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "uranium_triplatinum_ingot",
                NameRu = "Триплатина уран (Слиток)",
                NameEn = "Uranium triplatinum (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "ultimet_ingot",
                NameRu = "Ультимет (Слиток)",
                NameEn = "Ultimet (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "hssg_ingot",
                NameRu = "HSS-G (Слиток)",
                NameEn = "HSS-G (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "desh_ingot",
                NameRu = "Деш (Слиток)",
                NameEn = "desh (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tungsten_carbide_ingot",
                NameRu = "Карбид вольфрама (Слиток)",
                NameEn = "Tungsten carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "trinium_ingot",
                NameRu = "Триниум (Слиток)",
                NameEn = "Trinium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "neptunium_237_ingot",
                NameRu = "Нептуний 237 (Слиток)",
                NameEn = "Neptunium 237 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rhodium_plated_palladium_ingot",
                NameRu = "Палладий с родиевым покрытием (Слиток)",
                NameEn = "Rhodium plated palladium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "chromium_ingot",
                NameRu = "Хром (Слиток)",
                NameEn = "Chromium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "ostrum_iodide_ingot",
                NameRu = "Йодид острума (Слиток)",
                NameEn = "ostrum_iodide_dust (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "nickel_zinc_ferrite_ingot",
                NameRu = "Никель цинк феррит (Слиток)",
                NameEn = "Nickel zinc ferrite (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "titanium_carbide_ingot",
                NameRu = "Карбид титана (Слиток)",
                NameEn = "Titanium carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "samarium_ingot",
                NameRu = "Самарий (Слиток)",
                NameEn = "Samarium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "stainless_steel_ingot",
                NameRu = "Нержавеющая сталь (Слиток)",
                NameEn = "Stainless steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "bismuth_ingot",
                NameRu = "Висмут (Слиток)",
                NameEn = "Bismuth (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "bronze_ingot",
                NameRu = "Бронза (Слиток)",
                NameEn = "Bronze (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "ruthenium_trinium_americium_neutronate_ingot",
                NameRu = "Нейтронат рутения триния америция (Слиток)",
                NameEn = "Ruthenium trinium americium neutronate (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "incoloy_ma_956_ingot",
                NameRu = "Инколой MA-956 (Слиток)",
                NameEn = "Incoloy MA-956 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "brass_ingot",
                NameRu = "Латунь (Слиток)",
                NameEn = "Brass (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rtm_alloy_ingot",
                NameRu = "РВМ сплав (Слиток)",
                NameEn = "RTM alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "cobalt_brass_ingot",
                NameRu = "Кобальтовая латунь (Слиток)",
                NameEn = "Cobalt brass (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "neodymium_ingot",
                NameRu = "Неодим (Слиток)",
                NameEn = "Neodymium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "silicone_rubber_ingot",
                NameRu = "Силиконовая резина (Слиток)",
                NameEn = "Silicone rubber (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rubber_ingot",
                NameRu = "Резина (Слиток)",
                NameEn = "Rubber (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "black_steel_ingot",
                NameRu = "Черная сталь (Слиток)",
                NameEn = "Black steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "black_bronze_ingot",
                NameRu = "Черная бронза (Слиток)",
                NameEn = "Black bronze (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "zeron_100_ingot",
                NameRu = "Зерон-100 (Слиток)",
                NameEn = "Zeron-100 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnetic_samarium_ingot",
                NameRu = "Магнитный самарий (Слиток)",
                NameEn = "Magnetic samarium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "samarium_iron_arsenic_oxide_ingot",
                NameRu = "Оксид самария железа мышьяка (Слиток)",
                NameEn = "Samarium iron arsenic oxide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "blue_steel_ingot",
                NameRu = "Синяя сталь (Слиток)",
                NameEn = "Blue steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "manganese_phosphide_ingot",
                NameRu = "Фосфид марганца (Слиток)",
                NameEn = "Manganese phosphide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "stellite_100_ingot",
                NameRu = "Стеллит (Слиток)",
                NameEn = "Stellite (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "naquadria_ingot",
                NameRu = "Наквадрия (Слиток)",
                NameEn = "Naquadria (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "epoxy_ingot",
                NameRu = "Эпоксидная смола (Слиток)",
                NameEn = "Epoxy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnetic_neodymium_ingot",
                NameRu = "Магнитный неодим (Слиток)",
                NameEn = "Magnetic neodymium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "nichrome_ingot",
                NameRu = "Нихром (Слиток)",
                NameEn = "Nichrome (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "americium_ingot",
                NameRu = "Америций 241 (Слиток)",
                NameEn = "Americium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "europium_ingot",
                NameRu = "Европий (Слиток)",
                NameEn = "Europium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "thorium_230_ingot",
                NameRu = "Торий 230 (Слиток)",
                NameEn = "Thorium 230 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "vanadium_gallium_ingot",
                NameRu = "Ванадий-Галлий (Слиток)",
                NameEn = "Vanadium gallium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tungsten_ingot",
                NameRu = "Вольфрам (Слиток)",
                NameEn = "Tungsten (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "plutonium_ingot",
                NameRu = "Плутоний 239 (Слиток)",
                NameEn = "Plutonium 239 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "styrene_butadiene_rubber_ingot",
                NameRu = "Стирол-бутадиеновая резина (Слиток)",
                NameEn = "Styrene butadiene rubber (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "vanadium_steel_ingot",
                NameRu = "Ванадиевая сталь (Слиток)",
                NameEn = "Vanadium steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tungsten_steel_ingot",
                NameRu = "Вольфрамовая сталь (Слиток)",
                NameEn = "Tungsten steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnalium_ingot",
                NameRu = "Магналий (Слиток)",
                NameEn = "Magnalium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polybenzimidazole_ingot",
                NameRu = "Полибензимидазол (ПБИ) (Слиток)",
                NameEn = "Polybenzimidazole (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "iridium_ingot",
                NameRu = "Иридий (Слиток)",
                NameEn = "Iridium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "red_steel_ingot",
                NameRu = "Красная сталь (Слиток)",
                NameEn = "Red steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polyethylene_ingot",
                NameRu = "Полиэтилен (Слиток)",
                NameEn = "Polyethylene (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnetic_steel_ingot",
                NameRu = "Магнитная сталь (Слиток)",
                NameEn = "Magnetic steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "indium_gallium_phosphide_ingot",
                NameRu = "Индий галлий фосфид (Слиток)",
                NameEn = "Indium gallium phosphide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "indium_ingot",
                NameRu = "Индий (Слиток)",
                NameEn = "Indium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "osmium_ingot",
                NameRu = "Осмий (Слиток)",
                NameEn = "Osmium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "hastelloy_c_276_ingot",
                NameRu = "Хастеллой-C276 (Слиток)",
                NameEn = "Hastelloy-C276 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "molybdenum_disilicide_ingot",
                NameRu = "Дисилицид молибдена (Слиток)",
                NameEn = "molybdenum disilicide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rose_gold_ingot",
                NameRu = "Розовое золото (Слиток)",
                NameEn = "Rose gold (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "electrum_ingot",
                NameRu = "Электрум (Слиток)",
                NameEn = "Electrum (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tantalum_ingot",
                NameRu = "Тантал (Слиток)",
                NameEn = "Tantalum (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polydimethylsiloxane_ingot",
                NameRu = "Полидиметилсилоксан (Слиток)",
                NameEn = "polydimethylsiloxane (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polyvinyl_chloride_ingot",
                NameRu = "Поливинил хлорид (Слиток)",
                NameEn = "Polyvinyl chloride (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnesium_diboride_ingot",
                NameRu = "Диборид магния (Слиток)",
                NameEn = "Magnesium diboride (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "sterling_silver_ingot",
                NameRu = "Стерлинговое серебро (Слиток)",
                NameEn = "Sterling silver (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "wrought_iron_ingot",
                NameRu = "Кованное железо (Слиток)",
                NameEn = "Wrought iron (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tantalum_carbide_ingot",
                NameRu = "Карбид тантала (Слиток)",
                NameEn = "Tantalum carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "polytetrafluoroethylene_ingot",
                NameRu = "Политетрафторэтилен (Слиток)",
                NameEn = "Polytetrafluoroethylene (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "niobium_ingot",
                NameRu = "Ниобий (Слиток)",
                NameEn = "Niobium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "gallium_arsenide_ingot",
                NameRu = "Арсенид галлия (Слиток)",
                NameEn = "Gallium arsenide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "kanthal_ingot",
                NameRu = "Кантал (Слиток)",
                NameEn = "Kanthal (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "cadmium_ingot",
                NameRu = "Кадмий (Слиток)",
                NameEn = "Cadmium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "gold_ingot",
                NameRu = "Золото (Слиток)",
                NameEn = "Gold (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "vanadium_ingot",
                NameRu = "Ванадий (Слиток)",
                NameEn = "Vanadium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "uranium_rhodium_dinaquadide_ingot",
                NameRu = "Уран родий динаквада (Слиток)",
                NameEn = "Uranium rhodium dinaquadide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "yttrium_barium_cuprate_ingot",
                NameRu = "Оксид иттрия-бария-меди (Слиток)",
                NameEn = "Yttrium barium cuprate (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "reinforced_epoxy_resin_ingot",
                NameRu = "Укреплённая эпоксидная смола (Слиток)",
                NameEn = "Reinforced epoxy resin (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "maraging_steel_300_ingot",
                NameRu = "Мартенситностареющая сталь 300 (Слиток)",
                NameEn = "Maraging steel 300 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "enriched_naquadah_trinium_europium_duranide_ingot",
                NameRu = "Обогащенный наквада триний европий дюраний (Слиток)",
                NameEn = "Enriched naquadah trinium europium duranide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "palladium_ingot",
                NameRu = "Палладий (Слиток)",
                NameEn = "Palladium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "graphene_ingot",
                NameRu = "Графен (Слиток)",
                NameEn = "Graphene (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "beryllium_ingot",
                NameRu = "Бериллий (Слиток)",
                NameEn = "Beryllium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "blue_alloy_ingot",
                NameRu = "Синий сплав (Слиток)",
                NameEn = "Blue alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "hsse_ingot",
                NameRu = "HSS-E (Слиток)",
                NameEn = "HSS-E (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "mercury_barium_calcium_cuprate_ingot",
                NameRu = "Купрат ртути бария кальция (Слиток)",
                NameEn = "Mercury barium calcium cuprate (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "bismuth_bronze_ingot",
                NameRu = "Висмутовая бронза (Слиток)",
                NameEn = "Bismuth bronze (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "copper_ingot",
                NameRu = "Медь (Слиток)",
                NameEn = "Copper (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "silicon_ingot",
                NameRu = "Кремний (Слиток)",
                NameEn = "Silicon (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rocket_alloy_t2_ingot",
                NameRu = "ASM 4914 титановый ракетный сплав (Слиток)",
                NameEn = "Rocket alloy t2 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "naquadah_alloy_ingot",
                NameRu = "Сплав наквада (Слиток)",
                NameEn = "Naquadah alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "darmstadtium_ingot",
                NameRu = "Дармштадтий (Слиток)",
                NameEn = "Darmstadtium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "soldering_alloy_ingot",
                NameRu = "Припой (Слиток)",
                NameEn = "Soldering alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "battery_alloy_ingot",
                NameRu = "Аккумуляторный сплав (Слиток)",
                NameEn = "Battery alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "naquadah_ingot",
                NameRu = "Наквада (Слиток)",
                NameEn = "Naquadah (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "annealed_copper_ingot",
                NameRu = "Отожженная медь (Слиток)",
                NameEn = "Annealed copper (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "indium_tin_barium_titanium_cuprate_ingot",
                NameRu = "Купрат индия олова бария титана (Слиток)",
                NameEn = "Indium tin barium titanium cuprate (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "ostrum_ingot",
                NameRu = "Острум (Слиток)",
                NameEn = "Ostrum (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "yttrium_ingot",
                NameRu = "Иттрий (Слиток)",
                NameEn = "Yttrium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "lead_ingot",
                NameRu = "Свинец (Слиток)",
                NameEn = "Lead (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tin_alloy_ingot",
                NameRu = "Оловянный сплав (Слиток)",
                NameEn = "Tin alloy (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "steel_ingot",
                NameRu = "Сталь (Слиток)",
                NameEn = "Steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "aluminium_silicate_ingot",
                NameRu = "Алюмосиликат (Слиток)",
                NameEn = "Aluminium silicate (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tritanium_ingot",
                NameRu = "Тританий (Слиток)",
                NameEn = "Tritanium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "potin_ingot",
                NameRu = "Потин (Слиток)",
                NameEn = "Potin (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "magnesia_refractory_brick_ingot",
                NameRu = "Склеенный смолой магнезиальный огнеупорный кирпич (Слиток)",
                NameEn = "Magnesia refractory brick (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rough_silicon_carbide_ingot",
                NameRu = "Необработанный карбид кремния (Слиток)",
                NameEn = "Rough silicon carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "boron_carbide_ingot",
                NameRu = "Карбид бора (Слиток)",
                NameEn = "Boron carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "weak_red_steel_ingot",
                NameRu = "Сырая красная сталь (Слиток)",
                NameEn = "Weak red steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "weak_blue_steel_ingot",
                NameRu = "Сырая синяя сталь (Слиток)",
                NameEn = "Weak blue steel (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "bi_pb_sn_cd_in_tl_ingot",
                NameRu = "Bi-Pb-Cn-Cd-In-Tl (Слиток)",
                NameEn = "Bi-Pb-Cn-Cd-In-Tl (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "silicon_carbide_ingot",
                NameRu = "Карбид кремния (Слиток)",
                NameEn = "Silicon carbide (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "inconel_718_ingot",
                NameRu = "Инконель-718 (Слиток)",
                NameEn = "Inconel-718 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "bakelite_ingot",
                NameRu = "Бакелит (Слиток)",
                NameEn = "Bakelite (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "mo_50_re_ingot",
                NameRu = "Mo-50 Re (Слиток)",
                NameEn = "Mo-50 Re (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "weak_inconel_718_ingot",
                NameRu = "Слабый инконель-718 (Слиток)",
                NameEn = "Weak inconel-718 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "mo_si_b_ingot",
                NameRu = "Mo-Si-B (Слиток)",
                NameEn = "Mo-Si-B (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "calorite_ingot",
                NameRu = "Калорит (Слиток)",
                NameEn = "Calorite (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "woods_metal_ingot",
                NameRu = "Сплав Вуда (Слиток)",
                NameEn = "Woods metal (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "tungsten_bismuth_oxide_composite_ingot",
                NameRu = "Композит оксида-вольфрама-висмута (Слиток)",
                NameEn = "Tungsten bismuth oxide composite (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "zirconium_ingot",
                NameRu = "Цирконий (Слиток)",
                NameEn = "Zirconium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "rene_41_ingot",
                NameRu = "Рене-41 (Слиток)",
                NameEn = "Rene 41 (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "zirconium_diboride_ingot",
                NameRu = "Диборид циркония (Слиток)",
                NameEn = "Zirconium diboride (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "etrium_ingot",
                NameRu = "Этриум (Слиток)",
                NameEn = "Etrium (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "ruridit_ingot",
                NameRu = "Руридит (Слиток)",
                NameEn = "Ruridit (Ingot)",
                Type = "Слиток",
                Tag = "forge:ingots"
            },
            // ==========================================
            //               ГОРЯЧИЕ СЛИТКИ
            // ==========================================
            new GameItem
            {
                Id = "hot_worked_mo_si_b_ingot",
                NameRu = "Обработанный сплав Mo-Si_b (Горячий слиток)",
                NameEn = "Worked Mo-Si_b (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_weak_mo_si_b_ingot",
                NameRu = "Сплав Mo-Si_b (Горячий слиток)",
                NameEn = "Weak Mo-Si_b (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_homogenized_mo_si_b_ingot",
                NameRu = "Гомогенизированный сплав Mo-Si-B (Горячий слиток)",
                NameEn = "Homogenized Mo-Si-B (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_enriched_naquadah_ingot",
                NameRu = "Обогащённыя наквада (Горячий слиток)",
                NameEn = "Enriched naquadah (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_ruthenium_ingot",
                NameRu = "Рутений (Горячий слиток)",
                NameEn = "Ruthenium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_watertight_steel_ingot",
                NameRu = "Водостойкая сталь (Горячий слиток)",
                NameEn = "Watertight steel (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_osmiridium_ingot",
                NameRu = "Осмистый иридий (Горячий слиток)",
                NameEn = "Osmiridium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_titanium_tungsten_carbide_ingot",
                NameRu = "Вольфрам-титанановый карбид (Горячий слиток)",
                NameEn = "Titanium tungsten carbide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_niobium_titanium_ingot",
                NameRu = "Ниобий-титан (Горячий слиток)",
                NameEn = "Niobium titanium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rhodium_ingot",
                NameRu = "Родий (Горячий слиток)",
                NameEn = "Rhodium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_hsss_ingot",
                NameRu = "HSS-S (Горячий слиток)",
                NameEn = "HSS-S (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rocket_alloy_t1_ingot",
                NameRu = "Красный алюминиево-стальной ракетный сплав (Горячий слиток)",
                NameEn = "Rocket alloy t1 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_hastelloy_x_ingot",
                NameRu = "Хастеллой-X (Горячий слиток)",
                NameEn = "Hastelloy-X (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_niobium_nitride_ingot",
                NameRu = "Нитрид ниобия (Горячий слиток)",
                NameEn = "Niobium nitride (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_zirconium_ingot",
                NameRu = "Цирконий (Горячий слиток)",
                NameEn = "Zirconium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_titanium_ingot",
                NameRu = "Титан (Горячий слиток)",
                NameEn = "Titanium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_uranium_triplatinum_ingot",
                NameRu = "Триплатина уран (Горячий слиток)",
                NameEn = "Uranium triplatinum (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_ultimet_ingot",
                NameRu = "Ультимет (Горячий слиток)",
                NameEn = "Ultimet (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_hssg_ingot",
                NameRu = "HSS-G (Горячий слиток)",
                NameEn = "HSS-G (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_desh_ingot",
                NameRu = "Деш (Горячий слиток)",
                NameEn = "desh (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_tungsten_carbide_ingot",
                NameRu = "Карбид вольфрама (Горячий слиток)",
                NameEn = "Tungsten carbide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_trinium_ingot",
                NameRu = "Триниум (Горячий слиток)",
                NameEn = "Trinium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rhodium_plated_palladium_ingot",
                NameRu = "Палладий с родиевым покрытием (Горячий слиток)",
                NameEn = "Rhodium plated palladium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_ostrum_iodide_ingot",
                NameRu = "Йодид острума (Горячий слиток)",
                NameEn = "ostrum_iodide_dust (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_titanium_carbide_ingot",
                NameRu = "Карбид титана (Горячий слиток)",
                NameEn = "Titanium carbide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_samarium_ingot",
                NameRu = "Самарий (Горячий слиток)",
                NameEn = "Samarium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_ruthenium_trinium_americium_neutronate_ingot",
                NameRu = "Нейтронат рутения триния америция (Горячий слиток)",
                NameEn = "Ruthenium trinium americium neutronate (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_incoloy_ma_956_ingot",
                NameRu = "Инколой MA-956 (Горячий слиток)",
                NameEn = "Incoloy MA-956 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rtm_alloy_ingot",
                NameRu = "РВМ сплав (Горячий слиток)",
                NameEn = "RTM alloy (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_zeron_100_ingot",
                NameRu = "Зерон-100 (Горячий слиток)",
                NameEn = "Zeron-100 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_samarium_iron_arsenic_oxide_ingot",
                NameRu = "Оксид самария железа мышьяка (Горячий слиток)",
                NameEn = "Samarium iron arsenic oxide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_stellite_100_ingot",
                NameRu = "Стеллит (Горячий слиток)",
                NameEn = "Stellite (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_naquadria_ingot",
                NameRu = "Наквадрия (Горячий слиток)",
                NameEn = "Naquadria (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_nichrome_ingot",
                NameRu = "Нихром (Горячий слиток)",
                NameEn = "Nichrome (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_europium_ingot",
                NameRu = "Европий (Горячий слиток)",
                NameEn = "Europium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_vanadium_gallium_ingot",
                NameRu = "Ванадий-Галлий (Горячий слиток)",
                NameEn = "Vanadium gallium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_tungsten_ingot",
                NameRu = "Вольфрам (Горячий слиток)",
                NameEn = "Tungsten (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_tungsten_steel_ingot",
                NameRu = "Вольфрамовая сталь (Горячий слиток)",
                NameEn = "Tungsten steel (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_iridium_ingot",
                NameRu = "Иридий (Горячий слиток)",
                NameEn = "Iridium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_osmium_ingot",
                NameRu = "Осмий (Горячий слиток)",
                NameEn = "Osmium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_hastelloy_c_276_ingot",
                NameRu = "Хастеллой-C276 (Горячий слиток)",
                NameEn = "Hastelloy-C276 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_molybdenum_disilicide_ingot",
                NameRu = "Дисилицид молибдена (Горячий слиток)",
                NameEn = "molybdenum disilicide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_magnesium_diboride_ingot",
                NameRu = "Диборид магния (Горячий слиток)",
                NameEn = "Magnesium diboride (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_tantalum_carbide_ingot",
                NameRu = "Карбид тантала (Горячий слиток)",
                NameEn = "Tantalum carbide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_niobium_ingot",
                NameRu = "Ниобий (Горячий слиток)",
                NameEn = "Niobium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_kanthal_ingot",
                NameRu = "Кантал (Горячий слиток)",
                NameEn = "Kanthal (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_vanadium_ingot",
                NameRu = "Ванадий (Горячий слиток)",
                NameEn = "Vanadium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_uranium_rhodium_dinaquadide_ingot",
                NameRu = "Уран родий динаквада (Горячий слиток)",
                NameEn = "Uranium rhodium dinaquadide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_yttrium_barium_cuprate_ingot",
                NameRu = "Оксид иттрия-бария-меди (Горячий слиток)",
                NameEn = "Yttrium barium cuprate (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_maraging_steel_300_ingot",
                NameRu = "Мартенситностареющая сталь 300 (Горячий слиток)",
                NameEn = "Maraging steel 300 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_enriched_naquadah_trinium_europium_duranide_ingot",
                NameRu = "Обогащенный наквада триний европий дюраний (Горячий слиток)",
                NameEn = "Enriched naquadah trinium europium duranide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_palladium_ingot",
                NameRu = "Палладий (Горячий слиток)",
                NameEn = "Palladium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_hsse_ingot",
                NameRu = "HSS-E (Горячий слиток)",
                NameEn = "HSS-E (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_mercury_barium_calcium_cuprate_ingot",
                NameRu = "Купрат ртути бария кальция (Горячий слиток)",
                NameEn = "Mercury barium calcium cuprate (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_silicon_ingot",
                NameRu = "Кремний (Горячий слиток)",
                NameEn = "Silicon (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rocket_alloy_t2_ingot",
                NameRu = "ASM 4914 титановый ракетный сплав (Горячий слиток)",
                NameEn = "Rocket alloy t2 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_naquadah_alloy_ingot",
                NameRu = "Сплав наквада (Горячий слиток)",
                NameEn = "Naquadah alloy (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_naquadah_ingot",
                NameRu = "Наквада (Горячий слиток)",
                NameEn = "Naquadah (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_indium_tin_barium_titanium_cuprate_ingot",
                NameRu = "Купрат индия олова бария титана (Горячий слиток)",
                NameEn = "Indium tin barium titanium cuprate (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_ostrum_ingot",
                NameRu = "Острум (Горячий слиток)",
                NameEn = "Ostrum (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_yttrium_ingot",
                NameRu = "Иттрий (Горячий слиток)",
                NameEn = "Yttrium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rough_silicon_carbide_ingot",
                NameRu = "Необработанный карбид кремния (Горячий слиток)",
                NameEn = "Rough silicon carbide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_boron_carbide_ingot",
                NameRu = "Карбид бора (Горячий слиток)",
                NameEn = "Boron carbide (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_inconel_718_ingot",
                NameRu = "Инконель-718 (Горячий слиток)",
                NameEn = "Inconel-718 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_mo_si_b_ingot",
                NameRu = "Mo-Si-B (Горячий слиток)",
                NameEn = "Mo-Si-B (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_tungsten_bismuth_oxide_composite_ingot",
                NameRu = "Композит оксида-вольфрама-висмута (Горячий слиток)",
                NameEn = "Tungsten bismuth oxide composite (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_zirconium_ingot",
                NameRu = "Цирконий (Горячий слиток)",
                NameEn = "Zirconium (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_rene_41_ingot",
                NameRu = "Рене-41 (Горячий слиток)",
                NameEn = "Rene 41 (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_zirconium_diboride_ingot",
                NameRu = "Диборид циркония (Горячий слиток)",
                NameEn = "Zirconium diboride (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            new GameItem
            {
                Id = "hot_ruridit_ingot",
                NameRu = "Руридит (Горячий слиток)",
                NameEn = "Ruridit (Hot ingot)",
                Type = "Горячий слиток",
                Tag = "forge:hot_ingots"
            },
            // ==========================================
            //                    СТЕРЖНИ
            // ==========================================
            new GameItem
            {
                Id = "iron_rod",
                NameRu = "Серый чугун (Стержень)",
                NameEn = "Iron (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "red_garnet_rod",
                NameRu = "Красный гранат (Стержень)",
                NameEn = "Red garnet (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "silicone_rubber_rod",
                NameRu = "Силиконовая резина (Стержень)",
                NameEn = "Silicone rubber (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "certus_quartz_rod",
                NameRu = "Истинный кварц (Стержень)",
                NameEn = "Certus quartz (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "opal_rod",
                NameRu = "Опал (Стержень)",
                NameEn = "Opal (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "lapis_rod",
                NameRu = "Лазуритит (Стержень)",
                NameEn = "Lapis (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "styrene_butadiene_rubber_rod",
                NameRu = "Стирол-бутадиеновая резина (Стержень)",
                NameEn = "Styrene butadiene rubber (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "diamond_rod",
                NameRu = "Алмаз (Стержень)",
                NameEn = "Diamond (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "sodalite_rod",
                NameRu = "Содалит (Стержень)",
                NameEn = "Sodalite (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "yellow_garnet_rod",
                NameRu = "Желтый гранат (Стержень)",
                NameEn = " (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "nether_quartz_rod",
                NameRu = "Незер-кварц (Стержень)",
                NameEn = "Nether quartz (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "topaz_rod",
                NameRu = "Топаз (Стержень)",
                NameEn = "Topaz (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rubber_rod",
                NameRu = "Резина (Стержень)",
                NameEn = "Rubber (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "lazurite_rod",
                NameRu = "Лазурит (Стержень)",
                NameEn = "Lazurite (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "green_sapphire_rod",
                NameRu = "Зеленый сапфир (Стержень)",
                NameEn = "Green sapphire (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "emerald_rod",
                NameRu = "Изумруд (Стержень)",
                NameEn = "Emerald (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "amethyst_rod",
                NameRu = "Аметист (Стержень)",
                NameEn = "Amethyst (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "blue_topaz_rod",
                NameRu = "Синий топаз (Стержень)",
                NameEn = "Blue topaz (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "olivine_rod",
                NameRu = "Оливин (Стержень)",
                NameEn = "Olivine (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "quartzite_rod",
                NameRu = "Кварц (Стержень)",
                NameEn = "Quartzite (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "sapphire_rod",
                NameRu = "Сапфир (Стержень)",
                NameEn = "Sapphire (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "ruby_rod",
                NameRu = "Рубин (Стержень)",
                NameEn = "Ruby (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "ruridit_rod",
                NameRu = "Руридит (Стержень)",
                NameEn = "Ruridit (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "diamond_tipped_mo_50_re_rod",
                NameRu = "Mo-50Re с алмазным напылением (Стержень)",
                NameEn = "Diamond tipped Mo-50Re (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "red_alloy_rod",
                NameRu = "Красный сплав (Стержень)",
                NameEn = "Red alloy (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "neutronium_rod",
                NameRu = "Нейтроний (Стержень)",
                NameEn = "Neutronium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "uranium_rod",
                NameRu = "Уран 238 (Стержень)",
                NameEn = "Uranium 238 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "plutonium_241_rod",
                NameRu = "Плутоний-241 (Стержень)",
                NameEn = "Plutonium-241 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "platinum_rod",
                NameRu = "Платина (Стержень)",
                NameEn = "Platinum (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "enriched_naquadah_rod",
                NameRu = "Обогащённыя наквада (Стержень)",
                NameEn = "Enriched naquadah (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "aluminium_rod",
                NameRu = "Алюминий (Стержень)",
                NameEn = "Aluminium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "ruthenium_rod",
                NameRu = "Рутений (Стержень)",
                NameEn = "Ruthenium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "magnetic_iron_rod",
                NameRu = "Магнитное железо (Стержень)",
                NameEn = "Magnetic iron (Rod)",
                 Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "invar_rod",
                NameRu = "Инвар (Стержень)",
                NameEn = "Invar (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "duranium_rod",
                NameRu = "Дюраний (Стержень)",
                NameEn = "Duranium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "nickel_rod",
                NameRu = "Никель (Стержень)",
                NameEn = "Nickel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "zinc_rod",
                NameRu = "Цинк (Стержень)",
                NameEn = "Zinc (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "watertight_steel_rod",
                NameRu = "Водостойкая сталь (Стержень)",
                NameEn = "Watertight steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "thorium_232_rod",
                NameRu = "Торий 232 (Стержень)",
                NameEn = "Thorium 232 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "osmiridium_rod",
                NameRu = "Осмистый иридий (Стержень)",
                NameEn = "Osmiridium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "cobalt_rod",
                NameRu = "Кобальт (Стержень)",
                NameEn = "Cobalt (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "hsla_steel_rod",
                NameRu = "HSLA сталь (Стержень)",
                NameEn = "HSLA steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "manganese_rod",
                NameRu = "Марганец (Стержень)",
                NameEn = "Manganese (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "niobium_titanium_rod",
                NameRu = "Ниобий-титан (Стержень)",
                NameEn = "Niobium titanium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "silver_rod",
                NameRu = "Серебро (Стержень)",
                NameEn = "Silver (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rhodium_rod",
                NameRu = "Родий (Стержень)",
                NameEn = "Rhodium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "hsss_rod",
                NameRu = "HSS-S (Стержень)",
                NameEn = "HSS-S (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "molybdenum_rod",
                NameRu = "Молибден (Стержень)",
                NameEn = "molybdenum (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "polyphenylene_sulfide_rod",
                NameRu = "Полифениленсульфид (Стержень)",
                NameEn = "Polyphenylene sulfide (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tin_rod",
                NameRu = "Олово (Стержень)",
                NameEn = "Tin (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rocket_alloy_t1_rod",
                NameRu = "Красный алюминиево-стальной ракетный сплав (Стержень)",
                NameEn = "Rocket alloy t1 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "hastelloy_x_rod",
                NameRu = "Хастеллой-X (Стержень)",
                NameEn = "Hastelloy-X (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "niobium_nitride_rod",
                NameRu = "Нитрид ниобия (Стержень)",
                NameEn = "Niobium nitride (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "cupronickel_rod",
                NameRu = "Купроникель (Стержень)",
                NameEn = "Cupronickel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "titanium_rod",
                NameRu = "Титан (Стержень)",
                NameEn = "Titanium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "americium_rod",
                NameRu = "Америций 243 (Стержень)",
                NameEn = "Americium 243 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "uranium_235_rod",
                NameRu = "Уран-235 (Стержень)",
                NameEn = "Uranium-235 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "californium_252_rod",
                NameRu = "Калифорний 252 (Стержень)",
                NameEn = "Californium 252 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "ultimet_rod",
                NameRu = "Ультимет (Стержень)",
                NameEn = "Ultimet (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "hssg_rod",
                NameRu = "HSS-G (Стержень)",
                NameEn = "HSS-G (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "desh_rod",
                NameRu = "Деш (Стержень)",
                NameEn = "desh (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tungsten_carbide_rod",
                NameRu = "Карбид вольфрама (Стержень)",
                NameEn = "Tungsten carbide (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "trinium_rod",
                NameRu = "Триниум (Стержень)",
                NameEn = "Trinium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "neptunium_237_rod",
                NameRu = "Нептуний 237 (Стержень)",
                NameEn = "Neptunium 237 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rhodium_plated_palladium_rod",
                NameRu = "Палладий с родиевым покрытием (Стержень)",
                NameEn = "Rhodium plated palladium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "chromium_rod",
                NameRu = "Хром (Стержень)",
                NameEn = "Chromium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "ostrum_iodide_rod",
                NameRu = "Йодид острума (Стержень)",
                NameEn = "ostrum_iodide_dust (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "nickel_zinc_ferrite_rod",
                NameRu = "Никель цинк феррит (Стержень)",
                NameEn = "Nickel zinc ferrite (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "samarium_rod",
                NameRu = "Самарий (Стержень)",
                NameEn = "Samarium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "stainless_steel_rod",
                NameRu = "Нержавеющая сталь (Стержень)",
                NameEn = "Stainless steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "bismuth_rod",
                NameRu = "Висмут (Стержень)",
                NameEn = "Bismuth (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "bronze_rod",
                NameRu = "Бронза (Стержень)",
                NameEn = "Bronze (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "incoloy_ma_956_rod",
                NameRu = "Инколой MA-956 (Стержень)",
                NameEn = "Incoloy MA-956 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "brass_rod",
                NameRu = "Латунь (Стержень)",
                NameEn = "Brass (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rtm_alloy_rod",
                NameRu = "РВМ сплав (Стержень)",
                NameEn = "RTM alloy (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "cobalt_brass_rod",
                NameRu = "Кобальтовая латунь (Стержень)",
                NameEn = "Cobalt brass (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "neodymium_rod",
                NameRu = "Неодим (Стержень)",
                NameEn = "Neodymium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "black_steel_rod",
                NameRu = "Черная сталь (Стержень)",
                NameEn = "Black steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "black_bronze_rod",
                NameRu = "Черная бронза (Стержень)",
                NameEn = "Black bronze (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "magnetic_samarium_rod",
                NameRu = "Магнитный самарий (Стержень)",
                NameEn = "Magnetic samarium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "blue_steel_rod",
                NameRu = "Синяя сталь (Стержень)",
                NameEn = "Blue steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "naquadria_rod",
                NameRu = "Наквадрия (Стержень)",
                NameEn = "Naquadria (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "magnetic_neodymium_rod",
                NameRu = "Магнитный неодим (Стержень)",
                NameEn = "Magnetic neodymium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "nichrome_rod",
                NameRu = "Нихром (Стержень)",
                NameEn = "Nichrome (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "americium_rod",
                NameRu = "Америций 241 (Стержень)",
                NameEn = "Americium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "europium_rod",
                NameRu = "Европий (Стержень)",
                NameEn = "Europium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "thorium_230_rod",
                NameRu = "Торий 230 (Стержень)",
                NameEn = "Thorium 230 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "vanadium_gallium_rod",
                NameRu = "Ванадий-Галлий (Стержень)",
                NameEn = "Vanadium gallium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tungsten_rod",
                NameRu = "Вольфрам (Стержень)",
                NameEn = "Tungsten (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "plutonium_rod",
                NameRu = "Плутоний 239 (Стержень)",
                NameEn = "Plutonium 239 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "vanadium_steel_rod",
                NameRu = "Ванадиевая сталь (Стержень)",
                NameEn = "Vanadium steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tungsten_steel_rod",
                NameRu = "Вольфрамовая сталь (Стержень)",
                NameEn = "Tungsten steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "magnalium_rod",
                NameRu = "Магналий (Стержень)",
                NameEn = "Magnalium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "iridium_rod",
                NameRu = "Иридий (Стержень)",
                NameEn = "Iridium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "red_steel_rod",
                NameRu = "Красная сталь (Стержень)",
                NameEn = "Red steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "magnetic_steel_rod",
                NameRu = "Магнитная сталь (Стержень)",
                NameEn = "Magnetic steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "osmium_rod",
                NameRu = "Осмий (Стержень)",
                NameEn = "Osmium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "hastelloy_c_276_rod",
                NameRu = "Хастеллой-C276 (Стержень)",
                NameEn = "Hastelloy-C276 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "molybdenum_disilicide_rod",
                NameRu = "Дисилицид молибдена (Стержень)",
                NameEn = "molybdenum disilicide (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rose_gold_rod",
                NameRu = "Розовое золото (Стержень)",
                NameEn = "Rose gold (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "electrum_rod",
                NameRu = "Электрум (Стержень)",
                NameEn = "Electrum (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "polyvinyl_chloride_rod",
                NameRu = "Поливинил хлорид (Стержень)",
                NameEn = "Polyvinyl chloride (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "sterling_silver_rod",
                NameRu = "Стерлинговое серебро (Стержень)",
                NameEn = "Sterling silver (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "wrought_iron_rod",
                NameRu = "Кованное железо (Стержень)",
                NameEn = "Wrought iron (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "polytetrafluoroethylene_rod",
                NameRu = "Политетрафторэтилен (Стержень)",
                NameEn = "Polytetrafluoroethylene (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "kanthal_rod",
                NameRu = "Кантал (Стержень)",
                NameEn = "Kanthal (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "gold_rod",
                NameRu = "Золото (Стержень)",
                NameEn = "Gold (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "yttrium_barium_cuprate_rod",
                NameRu = "Оксид иттрия-бария-меди (Стержень)",
                NameEn = "Yttrium barium cuprate (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "maraging_steel_300_rod",
                NameRu = "Мартенситностареющая сталь 300 (Стержень)",
                NameEn = "Maraging steel 300 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "palladium_rod",
                NameRu = "Палладий (Стержень)",
                NameEn = "Palladium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "blue_alloy_rod",
                NameRu = "Синий сплав (Стержень)",
                NameEn = "Blue alloy (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "hsse_rod",
                NameRu = "HSS-E (Стержень)",
                NameEn = "HSS-E (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "bismuth_bronze_rod",
                NameRu = "Висмутовая бронза (Стержень)",
                NameEn = "Bismuth bronze (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "copper_rod",
                NameRu = "Медь (Стержень)",
                NameEn = "Copper (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rocket_alloy_t2_rod",
                NameRu = "ASM 4914 титановый ракетный сплав (Стержень)",
                NameEn = "Rocket alloy t2 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "naquadah_alloy_rod",
                NameRu = "Сплав наквада (Стержень)",
                NameEn = "Naquadah alloy (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "darmstadtium_rod",
                NameRu = "Дармштадтий (Стержень)",
                NameEn = "Darmstadtium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "battery_alloy_rod",
                NameRu = "Аккумуляторный сплав (Стержень)",
                NameEn = "Battery alloy (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "naquadah_rod",
                NameRu = "Наквада (Стержень)",
                NameEn = "Naquadah (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "annealed_copper_rod",
                NameRu = "Отожженная медь (Стержень)",
                NameEn = "Annealed copper (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "ostrum_rod",
                NameRu = "Острум (Стержень)",
                NameEn = "Ostrum (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "lead_rod",
                NameRu = "Свинец (Стержень)",
                NameEn = "Lead (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tin_alloy_rod",
                NameRu = "Оловянный сплав (Стержень)",
                NameEn = "Tin alloy (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "steel_rod",
                NameRu = "Сталь (Стержень)",
                NameEn = "Steel (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tritanium_rod",
                NameRu = "Тританий (Стержень)",
                NameEn = "Tritanium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "potin_rod",
                NameRu = "Потин (Стержень)",
                NameEn = "Potin (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "boron_carbide_rod",
                NameRu = "Карбид бора (Стержень)",
                NameEn = "Boron carbide (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "inconel_718_rod",
                NameRu = "Инконель-718 (Стержень)",
                NameEn = "Inconel-718 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "mo_50_re_rod",
                NameRu = "Mo-50 Re (Стержень)",
                NameEn = "Mo-50 Re (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "mo_si_b_rod",
                NameRu = "Mo-Si-B (Стержень)",
                NameEn = "Mo-Si-B (Rod)",
                Type = "Стержень",
                Tag = "forge:ingots"
            },
            new GameItem
            {
                Id = "calorite_rod",
                NameRu = "Калорит (Стержень)",
                NameEn = "Calorite (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "tungsten_bismuth_oxide_composite_rod",
                NameRu = "Композит оксида-вольфрама-висмута (Стержень)",
                NameEn = "Tungsten bismuth oxide composite (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "rene_41_rod",
                NameRu = "Рене-41 (Стержень)",
                NameEn = "Rene 41 (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            new GameItem
            {
                Id = "etrium_rod",
                NameRu = "Этриум (Стержень)",
                NameEn = "Etrium (Rod)",
                Type = "Стержень",
                Tag = "forge:rods"
            },
            // ==========================================
            //                  FLUIDS
            // ==========================================
            new GameItem
            {
                Id = "water_fluid",
                NameRu = "Вода",
                NameEn = "Water",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lava_fluid",
                NameRu = "Лава",
                NameEn = "Lava",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "milk_fluid",
                NameRu = "Молоко",
                NameEn = "Milk",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "weak_blue_steel_fluid",
                NameRu = "Сырая синяя сталь",
                NameEn = "Weak blue steel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "weak_red_steel_fluid",
                NameRu = "Сырая красная сталь",
                NameEn = "Weak red steel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lye_fluid",
                NameRu = "Щёлочь",
                NameEn = "Lye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "white_dye_fluid",
                NameRu = "Белый краситель",
                NameEn = "White",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "orange_dye_fluid",
                NameRu = "Оранжевый краситель",
                NameEn = "Orange",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "magenta_dye_fluid",
                NameRu = "Пурпурный краситель",
                NameEn = "Magenta dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "light_blue_dye_fluid",
                NameRu = "Голубой краситель",
                NameEn = "Light blue dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "yellow_dye_fluid",
                NameRu = "Желтый краситель",
                NameEn = "Yellow dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lime_dye_fluid",
                NameRu = "Лаймовый краситель",
                NameEn = "Lime dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "pink_dye_fluid",
                NameRu = "Розовый краситель",
                NameEn = "Pink dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "gray_dye_fluid",
                NameRu = "Серый краситель",
                NameEn = "Gray dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "light_gray_dye_fluid",
                NameRu = "Светло-серый краситель",
                NameEn = "Light gray dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cyan_dye_fluid",
                NameRu = "Бирюзовый краситель",
                NameEn = "Cyan dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "purple_dye_fluid",
                NameRu = "Фиолетовый краситель",
                NameEn = "Purple dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "blue_dye_fluid",
                NameRu = "Синий краситель",
                NameEn = "Blue dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "brown_dye_fluid",
                NameRu = "Коричневый краситель",
                NameEn = "Brown dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "green_dye_fluid",
                NameRu = "Зеленый краситель",
                NameEn = "Green dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "red_dye_fluid",
                NameRu = "Красный краситель",
                NameEn = "Red dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "black_dye_fluid",
                NameRu = "Черный краситель",
                NameEn = "Black dye",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_magnesium_diboride",
                NameRu = "Расплав (Диборид магния)",
                NameEn = "Molten (Magnesium diboride)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_hsss",
                NameRu = "Расплав (HSS-S)",
                NameEn = "Molten (HSS-S)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_hsse",
                NameRu = "Расплав (HSS-E)",
                NameEn = "Molten (HSS-E)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_hssg",
                NameRu = "Расплав (HSS-G)",
                NameEn = "Molten (HSS-G)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_zeron_100",
                NameRu = "Расплав (Зерон-100)",
                NameEn = "Molten (Zeron-100)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_naquadah_alloy",
                NameRu = "Расплав (Сплав наквада)",
                NameEn = "Molten (Naquadah alloy)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_enriched_naquadah_trinium_europium_duranide",
                NameRu = "Расплав (Обогащенный наквада триний европий дюраний)",
                NameEn = "Molten (Enriched naquadah trinium europium duranide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_ostrum_iodide",
                NameRu = "Расплав (йодид острума)",
                NameEn = "Molten (Ostrum iodide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_stellite_100",
                NameRu = "Расплав (Стеллит)",
                NameEn = "Molten (Stellite)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_indium_tin_barium_titanium_cuprate",
                NameRu = "Расплав (Купрат Индия Олова Бария Титана)",
                NameEn = "Molten (Indium Tin Barium Titanium Cuprate)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_tantalum_carbide",
                NameRu = "Расплав (Карбид тантала)",
                NameEn = "Molten (Tantalum carbide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_rocket_alloy_t2",
                NameRu = "Расплав (ASM 4914 титановый ракетный сплав)",
                NameEn = "Molten (Rocket alloy t2)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_ultimet",
                NameRu = "Расплав (Ультимет)",
                NameEn = "Molten (Ultimet)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_titanium_carbide",
                NameRu = "Расплав (Карбид титана)",
                NameEn = "Molten (Titanium carbide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_mercury_barium_calcium_cuprate",
                NameRu = "Расплав (Купрат ртути бария кальция)",
                NameEn = "Molten (Mercury barium calcium cuprate)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_uranium_rhodium_dinaquadide",
                NameRu = "Расплав (Уран родий динаквада)",
                NameEn = "Molten (Uranium rhodium dinaquadide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_niobium_titanium",
                NameRu = "Расплав (Ниобий-титан)",
                NameEn = "Molten (Niobium titanium)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_ruthenium_trinium_americium_neutronate",
                NameRu = "Расплав (Нейтронат рутения триния америция)",
                NameEn = "Molten (Ruthenium trinium americium neutronate)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_incoloy_ma_956",
                NameRu = "Расплав (Инколой MA-956)",
                NameEn = "Molten (Incoloy MA-956)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_niobium_nitride",
                NameRu = "Расплав (Нитрид ниобия)",
                NameEn = "Molten (Niobium nitride)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_rhodium_plated_palladium",
                NameRu = "Расплав (Палладий с родиевым покрытием)",
                NameEn = "Molten (Rhodium plated palladium)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_yttrium_barium_cuprate",
                NameRu = "Расплав (Оксид иттрия-бария-меди)",
                NameEn = "Molten (Yttrium Barium Cuprate)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_nichrome",
                NameRu = "Расплав (Нихром)",
                NameEn = "Molten (Nichrome)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_tungsten_carbide",
                NameRu = "Расплав (Карбид вольфрама)",
                NameEn = "Molten (Tungsten carbide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_ruridit",
                NameRu = "Расплав (Руридит)",
                NameEn = "Molten (Ruridit)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_osmiridium",
                NameRu = "Расплав (Осмистый иридий)",
                NameEn = "Molten (Osmiridium)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_vanadium_gallium",
                NameRu = "Расплав (Ванадий-галлий)",
                NameEn = "Molten (Vanadium gallium)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_tungsten_steel",
                NameRu = "Расплав (Вольфрамовая сталь)",
                NameEn = "Molten (Tungsten steel)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_hastelloy_c_276",
                NameRu = "Расплав (Хастеллой-С276)",
                NameEn = "Molten (Hastelloy-C276)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_molybdenum_disilicide",
                NameRu = "Расплав (Дисилицид молибдена)",
                NameEn = "Molten (molybdenum disilicide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_titanium_tungsten_carbide",
                NameRu = "Расплав (Вольфрам-титановый карбид)",
                NameEn = "Molten (Titanium tungsten carbide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_samarium_iron_arsenic_oxide",
                NameRu = "Расплав (Оксид Самария Железа Мышьяка)",
                NameEn = "Molten (Samarium Iron Arsenic Oxide)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_uranium_triplatinum",
                NameRu = "Расплав (Триплатина уран)",
                NameEn = "Molten (Uranium triplatinum)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_rtm_alloy",
                NameRu = "Расплав (РВМ сплав)",
                NameEn = "Molten (RTM alloy)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_kanthal",
                NameRu = "Расплав (Кантал)",
                NameEn = "Molten (Kanthal)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_maraging_steel_300",
                NameRu = "Расплав (Мартенситностареющая сталь 300)",
                NameEn = "Molten (Maraging steel 300)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_watertight_steel",
                NameRu = "Расплав (Водостойкая сталь)",
                NameEn = "Molten (Watertight steel)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_hassteloy_x",
                NameRu = "Расплав (Хастеллой-X)",
                NameEn = "Molten (Hastelloy-X)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_ostrum",
                NameRu = "Расплав (Острум)",
                NameEn = "Molten (Ostrum)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_red_steel",
                NameRu = "Расплав (Красная сталь)",
                NameEn = "Molten (Red steel)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_blue_steel",
                NameRu = "Расплав (Синяя сталь)",
                NameEn = "Molten (Blue steel)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_black_steel",
                NameRu = "Расплав (Черная сталь)",
                NameEn = "Molten (Black steel)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_tungsten_bismuth_oxide_composite",
                NameRu = "Расплав (Композит оксида вольфрама-висмута)",
                NameEn = "Molten (Tungsten bismuth oxide composite)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_rene_41",
                NameRu = "Расплав (Рене-41)",
                NameEn = "Molten (Rene-41)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_aes",
                NameRu = "Расплавленный щелочноземельный силикат",
                NameEn = "Molten aes",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molten_mo_50_re",
                NameRu = "Расплав (Mo-50 Re)",
                NameEn = "Molten (Mo-50 Re)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "aqua_regia_fluid",
                NameRu = "Царская водка",
                NameEn = "Aqua regia",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_hydro_cracked_light_fuel_fluid",
                NameRu = "Легкое топливо прошедшее тяжелый крекинг водородом",
                NameEn = "Severely hydro cracked light fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_acid_fluid",
                NameRu = "Серная кислота",
                NameEn = "Sulfuric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sterilized_growth_medium_fluid",
                NameRu = "Стерилизованная среда роста",
                NameEn = "Sterilized growth medium",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "formic_acid_fluid",
                NameRu = "Муравьиная кислота",
                NameEn = "Formic acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "biomass_fluid",
                NameRu = "Биомасса",
                NameEn = "Biomass",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "iron_iii_chloride_fluid",
                NameRu = "Хлорид железа (III)",
                NameEn = "Iron (III) chloride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "glue_fluid",
                NameRu = "Клей",
                NameEn = "Glue",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "liquid_carbon_dioxide_fluid",
                NameRu = "Сжиженный углекислый газ",
                NameEn = "Liquid carbon dioxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "fluoroantimonic_acid_fluid",
                NameRu = "Фторантимоновая кислота",
                NameEn = "Fluoroantimonic acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "titanium_tetrachloride_fluid",
                NameRu = "Тетрахлорид титана",
                NameEn = "Titanium tetrachloride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "gelatin_mixture_fluid",
                NameRu = "Желатиновая смесь",
                NameEn = "Gelatin mixture",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "glycolonitrile_fluid",
                NameRu = "Гликолонитрил",
                NameEn = "Glycolonitrile",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tetranitromethane_fluid",
                NameRu = "Тетранитрометан",
                NameEn = "Tetranitromethane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "residual_radioactive_concoction_fluid",
                NameRu = "Остаточная радиоактивная смесь",
                NameEn = "Residual radioactive concoction",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "salt_water_fluid",
                NameRu = "Соленая вода",
                NameEn = "Salt water",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naphthalene_fluid",
                NameRu = "Нафталин",
                NameEn = "Naphthalene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bacterial_sludge_fluid",
                NameRu = "Бактериальный ил",
                NameEn = "Bacterial sludge",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hypochlorous_acid_fluid",
                NameRu = "Хлорноватистая кислота",
                NameEn = "Hypochlorous acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naphtha_fluid",
                NameRu = "Нафта",
                NameEn = "naphtha",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "methyl_acetate_fluid",
                NameRu = "Метилацетат",
                NameEn = "Methyl acetate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cetane_boosted_diesel_fluid",
                NameRu = "Нитро-дизель",
                NameEn = "Cetane boosted diesel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diluted_sulfuric_acid_fluid",
                NameRu = "Разбавленная серная кислота",
                NameEn = "Diluted sulfuric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_naphtha_fluid",
                NameRu = "Серная нафта",
                NameEn = "Sulfuric naphtha",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dichlorobenzidine_fluid",
                NameRu = "Дихлорбензол",
                NameEn = "Dichlorobenzidine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "allyl_chloride_fluid",
                NameRu = "Аллилхлорид",
                NameEn = "Allyl chloride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "oil_medium_fluid",
                NameRu = "Средняя нефть",
                NameEn = "Oil medium",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sodium_persulfate_fluid",
                NameRu = "Персульфат натрия",
                NameEn = "Sodium persulfate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "toluene_fluid",
                NameRu = "Толуол",
                NameEn = "Toluene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lubricant_fluid",
                NameRu = "Смазка",
                NameEn = "Lubricant",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_steam_cracked_naphtha_fluid",
                NameRu = "Нафта прошедшая жесткий крекинг паром",
                NameEn = "Severely steam cracked naphtha",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "acetic_anhydride_fluid",
                NameRu = "Уксусный ангидрид",
                NameEn = "Acetic anhydride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_steam_cracked_heavy_fuel_fluid",
                NameRu = "Тяжелое топливо прошедшее легкий крекинг паром",
                NameEn = "Lightly steam cracked heavy fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uranium_waste_fluid",
                NameRu = "Урановые отходы",
                NameEn = "Uranium waste",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "phosphoric_acid_fluid",
                NameRu = "Фосфорная кислота",
                NameEn = "Phosphoric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "enriched_naquadah_waste_fluid",
                NameRu = "Обогащенные отходы наквады",
                NameEn = "Enriched naquadah waste",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "distilled_water_fluid",
                NameRu = "Дистиллированная вода",
                NameEn = "Distilled water",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dimethylhydrazine_fluid",
                NameRu = "1,1-Диметилгидразин",
                NameEn = "Dimethylhydrazine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dichlorobenzene_fluid",
                NameRu = "Дихлорбензол",
                NameEn = "Dichlorobenzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "benzene_fluid",
                NameRu = "Бензол",
                NameEn = "Benzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "phenol_fluid",
                NameRu = "Фенол",
                NameEn = "Phenol",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "acidic_naquadria_solution_fluid",
                NameRu = "Кислота раствора наквадрии",
                NameEn = "Acidic naquadria solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "heavy_fuel_fluid",
                NameRu = "Тяжелое топливо",
                NameEn = "Heavy fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_steam_cracked_heavy_fuel_fluid",
                NameRu = "Тяжелое топливо прошедшее жесткий крекинг паром",
                NameEn = "Severely steam cracked heavy fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_hydro_cracked_light_fuel_fluid",
                NameRu = "Легкое топливо прошедшее легкий крекинг водородом",
                NameEn = "Lightly hydro cracked light fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "butyraldehyde_fluid",
                NameRu = "Бутиральдегид",
                NameEn = "Butyraldehyde",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "formamide_fluid",
                NameRu = "Формамид",
                NameEn = "Formamide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrogen_peroxide_fluid",
                NameRu = "Перекись водорода",
                NameEn = "Hydrogen peroxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ethyl_tertbutyl_ether_fluid",
                NameRu = "Трет-бутилэтиловый эфир",
                NameEn = "Ethyl tertbutyl ether",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "wood_vinegar_fluid",
                NameRu = "Древесный уксус",
                NameEn = "Wood vinegar",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naquadria_solution_fluid",
                NameRu = "Раствор наквадрии",
                NameEn = "Naquadria solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "formaldehyde_fluid",
                NameRu = "Формальдегид",
                NameEn = "Formaldehyde",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "vinyl_acetate_fluid",
                NameRu = "Винилацетат",
                NameEn = "Vinyl acetate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bisphenol_a_fluid",
                NameRu = "Бисфенол А",
                NameEn = "Bisphenol A",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uu_matter_fluid",
                NameRu = "UU-материя",
                NameEn = "UU-matter",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "seed_oil_fluid",
                NameRu = "Растительное масло",
                NameEn = "Seed oil",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "fish_oil_fluid",
                NameRu = "Рыбий жир",
                NameEn = "Fish oil",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bauxite_slurry_fluid",
                NameRu = "Бокситовая суспензия",
                NameEn = "Bauxite slurry",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "epichlorohydrin_fluid",
                NameRu = "Эпихлоргидрин",
                NameEn = "Epichlorohydrin",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitration_mixture_fluid",
                NameRu = "Нитратная смесь",
                NameEn = "Nitration mixture",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_copper_solution_fluid",
                NameRu = "Водный раствор медного купороса",
                NameEn = "Sulfuric copper solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "oil_light_fluid",
                NameRu = "Легкая нефть",
                NameEn = "Oil light",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dirty_hexafluorosilicic_acid_fluid",
                NameRu = "Грязная гексафторкремниевая кислота",
                NameEn = "Dirty hexafluorosilicic acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lpg_fluid",
                NameRu = "Сжиженный углеводородный газ",
                NameEn = "LPG",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "enriched_bacterial_sludge_fluid",
                NameRu = "Обогащенный бактериальный ил",
                NameEn = "Enriched bacterial sludge",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "martian_sludge_fluid",
                NameRu = "Марсианская слякоть",
                NameEn = "Martian sludge",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "mercury_fluid",
                NameRu = "Ртуть",
                NameEn = "Mercury",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "impure_naquadria_solution_fluid",
                NameRu = "Загрязненный раствор наквадрии",
                NameEn = "Impure naquadria solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polychlorinated_biphenyl_fluid",
                NameRu = "Полихлорированный дифенил (ПХД)",
                NameEn = "Polychlorinated biphenyl",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "aminophenol_fluid",
                NameRu = "Аминофенол",
                NameEn = "Aminophenol",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "chloroform_fluid",
                NameRu = "Хлороформ",
                NameEn = "Chloroform",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dimethylbenzene_fluid",
                NameRu = "Ксилол",
                NameEn = "Dimethylbenzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ethenone_fluid",
                NameRu = "Кетен",
                NameEn = "Ethenone",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ethylbenzene_fluid",
                NameRu = "Этилбензол",
                NameEn = "Ethylbenzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "iron_ii_chloride_fluid",
                NameRu = "Хлорид железа (II)",
                NameEn = "Iron (II) chloride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_steam_cracked_light_fuel_fluid",
                NameRu = "Легкое топливо прошедшее жесткий крекинг паром",
                NameEn = "Severely steam cracked light fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_hydro_cracked_naphtha_fluid",
                NameRu = "Нафта прошедшая тяжелый крекинг водородом",
                NameEn = "Severely hydro cracked naphtha",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_hydro_cracked_heavy_fuel_fluid",
                NameRu = "Тяжелое топливо прошедшее легкий крекинг водородом",
                NameEn = "Lightly hydro cracked heavy fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "chlorobenzene_fluid",
                NameRu = "Хлорбензол",
                NameEn = "Chlorobenzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "oil_heavy_fluid",
                NameRu = "Тяжелая нефть",
                NameEn = "Oil heavy",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "methanol_fluid",
                NameRu = "Метанол",
                NameEn = "Methanol",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "glycerol_fluid",
                NameRu = "Глицерин",
                NameEn = "Glycerol",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "concrete_fluid",
                NameRu = "Бетон",
                NameEn = "Concrete",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "coal_tar_fluid",
                NameRu = "Каменноугольная смола",
                NameEn = "Coal tar",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "fermented_biomass_fluid",
                NameRu = "Ферментированная биомасса",
                NameEn = "Fermented biomass",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "pcb_coolant_fluid",
                NameRu = "Диэлектрический хладоген (ПХД)",
                NameEn = "PCB coolant",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "isoprene_fluid",
                NameRu = "Изопрен",
                NameEn = "Isoprene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cracked_bauxite_slurry_fluid",
                NameRu = "Бокситовая суспензия прошедшая крекинг",
                NameEn = "Cracked bauxite slurry",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "phthalic_acid_fluid",
                NameRu = "Фталиевая кислота",
                NameEn = "Phthalic acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitrochlorobenzene_fluid",
                NameRu = "Нитрохлорбензол",
                NameEn = "Nitrochlorobenzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_light_fuel_fluid",
                NameRu = "Серное легкое топливо",
                NameEn = "Sulfuric light fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rocket_fuel_fluid",
                NameRu = "Ракетное топливо",
                NameEn = "Rocket fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bromine_fluid",
                NameRu = "Бром",
                NameEn = "Bromine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "creosote_fluid",
                NameRu = "Креозот",
                NameEn = "Creosote",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lead_zinc_solution_fluid",
                NameRu = "Свинцово-цинковый раствор",
                NameEn = "Lead zinc solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "decalcified_bauxite_sludge_fluid",
                NameRu = "Декальцированный шлам боксита",
                NameEn = "Decalcified bauxite sludge",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ethanol_fluid",
                NameRu = "Этанол",
                NameEn = "Ethanol",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "gasoline_fluid",
                NameRu = "Бензин",
                NameEn = "Gasoline",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "high_octane_gasoline_fluid",
                NameRu = "Высокооктановый бензин",
                NameEn = "High octane gasoline",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_steam_cracked_naphtha_fluid",
                NameRu = "Нафта прошедшая легкий крекинг паром",
                NameEn = "Lightly steam cracked naphtha",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dissolved_calcium_acetate_fluid",
                NameRu = "Раствор ацетата кальция",
                NameEn = "Dissolved calcium acetate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "raw_gasoline_fluid",
                NameRu = "Сырой бензин",
                NameEn = "Raw gasoline",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "drilling_fluid",
                NameRu = "Буровой раствор",
                NameEn = "Drilling fluid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "indium_concentrate_fluid",
                NameRu = "Концетрат индия",
                NameEn = "Indium concentrate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_hydro_cracked_naphtha_fluid",
                NameRu = "Нафта прошедшая легкий крекинг водородом",
                NameEn = "Lightly hydro cracked naphtha",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sodium_potassium_fluid",
                NameRu = "Натрий калий",
                NameEn = "Sodium potassium",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_nickel_solution_fluid",
                NameRu = "Водный раствор сульфата никеля",
                NameEn = "Sulfuric nickel solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diethylenetriamine_fluid",
                NameRu = "Диэтилентриамин",
                NameEn = "Diethylenetriamine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "enriched_naquadah_solution_fluid",
                NameRu = "Обогащенный раствор наквады",
                NameEn = "Enriched naquadah solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bio_diesel_fluid",
                NameRu = "Биодизель",
                NameEn = "Bio diesel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rhodium_sulfate_fluid",
                NameRu = "Сульфат родия",
                NameEn = "Rhodium sulfate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cyclohexane_fluid",
                NameRu = "Циклогексан",
                NameEn = "Cyclohexane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diesel_fluid",
                NameRu = "Дизель",
                NameEn = "Diesel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrochloric_acid_fluid",
                NameRu = "Хлороводород",
                NameEn = "Hydrochloric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "styrene_fluid",
                NameRu = "Стирол",
                NameEn = "Styrene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diluted_hydrochloric_acid_fluid",
                NameRu = "Разбавленный хлороводород",
                NameEn = "Diluted hydrochloric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "light_fuel_fluid",
                NameRu = "Легкое топливо",
                NameEn = "Light fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bauxite_sludge_fluid",
                NameRu = "Шлам боксита",
                NameEn = "Bauxite sludge",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diaminobenzidine_fluid",
                NameRu = "Диаминобензидин",
                NameEn = "Diaminobenzidine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tritiated_water_fluid",
                NameRu = "Тритиевая вода",
                NameEn = "Tritiated water",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diphenyl_isophthalate_fluid",
                NameRu = "Дифенилизофталат",
                NameEn = "Diphenyl isophthalate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_heavy_fuel_fluid",
                NameRu = "Серное тяжелое топливо",
                NameEn = "Sulfuric heavy fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bacteria_fluid",
                NameRu = "Бактерии",
                NameEn = "Bacteria",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "oil_fluid",
                NameRu = "Нефть",
                NameEn = "Oil",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_hydro_cracked_heavy_fuel_fluid",
                NameRu = "Тяжелое топливо прошедшее тяжелый крекинг водородом",
                NameEn = "Severely hydro cracked heavy fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "acetone_fluid",
                NameRu = "Ацетон",
                NameEn = "Acetone",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "charcoal_byproducts_fluid",
                NameRu = "Продукты переработки древесного угля",
                NameEn = "Charcoal byproducts",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "mutagen_fluid",
                NameRu = "Мутаген",
                NameEn = "Mutagen",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "liquid_air_fluid",
                NameRu = "Сжиженный земной воздух",
                NameEn = "Liquid air",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dichloroethane_fluid",
                NameRu = "Дихлорэтан",
                NameEn = "Dichloroethane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "glyceryl_trinitrate_fluid",
                NameRu = "Нитроглицерин",
                NameEn = "Glyceryl trinitrate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "acidic_enriched_naquadah_solution_fluid",
                NameRu = "Кислота обогащенного раствора наквады",
                NameEn = "Acidic enriched naquadah solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dioxygen_difluoride_fluid",
                NameRu = "Диоксифторид",
                NameEn = "Dioxygen difluoride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "wood_tar_fluid",
                NameRu = "Древесная смола",
                NameEn = "Wood tar",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naquadria_waste_fluid",
                NameRu = "Наквадриевые отходы",
                NameEn = "Naquadria waste",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "acetic_acid_fluid",
                NameRu = "Уксусная кислота",
                NameEn = "Acetic acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "acidic_osmium_solution_fluid",
                NameRu = "Раствор осмиевой кислоты",
                NameEn = "Acidic osmium solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "raw_growth_medium_fluid",
                NameRu = "Сырая среда роста",
                NameEn = "Raw growth medium",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_steam_cracked_light_fuel_fluid",
                NameRu = "Легкое топливо прошедшее легкий крекинг паром",
                NameEn = "Lightly steam cracked light fuel",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "octane_fluid",
                NameRu = "Октан",
                NameEn = "Octane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "impure_enriched_naquadah_solution_fluid",
                NameRu = "Загрязненный обогащенный раствор наквады",
                NameEn = "Impure enriched naquadah solution",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitric_acid_fluid",
                NameRu = "Азотная кислота",
                NameEn = "Nitric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "diethylenetriamine_pentaacetonitrile_fluid",
                NameRu = "Диэтилентриамин-пента",
                NameEn = "Diethylenetriamine pentaacetonitrile",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polyvinyl_acetate_fluid",
                NameRu = "Поливинилацетат",
                NameEn = "Polyvinyl acetate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrofluoric_acid_fluid",
                NameRu = "Плавиковая кислота",
                NameEn = "Hydrofluoric acid",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "construction_foam_fluid",
                NameRu = "Строительная пена",
                NameEn = "Construction foam",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "potin_fluid",
                NameRu = "Потин (Жидкость)",
                NameEn = "Potin (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "soldering_alloy_fluid",
                NameRu = "Припой (Жидкость)",
                NameEn = "Soldering alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "neutronium_fluid",
                NameRu = "Нейтроний (Жидкость)",
                NameEn = "Neutronium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "silver_fluid",
                NameRu = "Серебро (Жидкость)",
                NameEn = "Silver (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sterling_silver_fluid",
                NameRu = "Стерлинговое серебро (Жидкость)",
                NameEn = "Sterling silver (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polyphenylene_sulfide_fluid",
                NameRu = "Полифениленсульфид (Жидкость)",
                NameEn = "Polyphenylene sulfide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "magnalium_fluid",
                NameRu = "Магналий (Жидкость)",
                NameEn = "Magnalium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "magnesium_diboride_fluid",
                NameRu = "Диборид магния (Жидкость)",
                NameEn = "Magnesium diboride (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "manganese_phosphide_fluid",
                NameRu = "Фосфид марганца (Жидкость)",
                NameEn = "Manganese phosphide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "carbon_fluid",
                NameRu = "Углерод (Жидкость)",
                NameEn = "Carbon (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ostrum_fluid",
                NameRu = "Острум (Жидкость)",
                NameEn = "Ostrum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "zeron_100_fluid",
                NameRu = "Зерон-100 (Жидкость)",
                NameEn = "Zeron 100 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naquadah_alloy_fluid",
                NameRu = "Сплав наквада (Жидкость)",
                NameEn = "Naquadah alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bronze_fluid",
                NameRu = "Бронза (Жидкость)",
                NameEn = "Bronze (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "indium_gallium_phosphide_fluid",
                NameRu = "Индий Галлий Фосфид (Жидкость)",
                NameEn = "Indium_gallium_phosphide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "vanadium_fluid",
                NameRu = "Ванадий (Жидкость)",
                NameEn = "Vanadium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "enriched_naquadah_trinium_europium_duranide_fluid",
                NameRu = "Обогащенный наквада триний европий дюраний (Жидкость)",
                NameEn = "Enriched naquadah trinium europium duranide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ostrum_iodide_fluid",
                NameRu = "йодид острума (Жидкость)",
                NameEn = "Ostrum iodide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "stellite_100_fluid",
                NameRu = "Стеллит (Жидкость)",
                NameEn = "Stellite (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "chromium_fluid",
                NameRu = "Хром (Жидкость)",
                NameEn = "Chromium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "annealed_copper_fluid",
                NameRu = "Отожженная медь (Жидкость)",
                NameEn = "Annealed copper (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "plutonium_239_fluid",
                NameRu = "Плутоний 239 (Жидкость)",
                NameEn = "Plutonium 239 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "potassium_fluid",
                NameRu = "Калий (Жидкость)",
                NameEn = "Potassium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "indium_tin_barium_titanium_cuprate_fluid",
                NameRu = "Купрат Индия Олова Бария Титана (Жидкость)",
                NameEn = "Indium Tin Barium Titanium Cuprate (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "liquid_helium_fluid",
                NameRu = "Гелий (Жидкость)",
                NameEn = "Helium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tantalum_fluid",
                NameRu = "Тантал (Жидкость)",
                NameEn = "Tantalum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "styrene_butadiene_rubber_fluid",
                NameRu = "Стирол-бутадиенова резина (Жидкость)",
                NameEn = "Styrene butadiene rubber (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lutetium_fluid",
                NameRu = "Лютеций (Жидкость)",
                NameEn = "Lutetium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tantalum_carbide_fluid",
                NameRu = "Карбид тантала (Жидкость)",
                NameEn = "Tantalum carbide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rocket_alloy_t2_fluid",
                NameRu = "ASM 4914 титановый ракетный сплав (Жидкость)",
                NameEn = "Rocket alloy t2 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "liquid_oxygen_fluid",
                NameRu = "Кислород (Жидкость)",
                NameEn = "Oxygen (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "epoxy_fluid",
                NameRu = "Эпоксидная смола (Жидкость)",
                NameEn = "Epoxy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bismuth_bronze_fluid",
                NameRu = "Висмутовая бронза (Жидкость)",
                NameEn = "Bismuth bronze (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "concrete_fluid",
                NameRu = "Бетон (Жидкость)",
                NameEn = "Concrete (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "antimony_fluid",
                NameRu = "Сурьма (Жидкость)",
                NameEn = "Antimony (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ultimet_fluid",
                NameRu = "Ультимет (Жидкость)",
                NameEn = "Ultimet (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polycaprolactam_fluid",
                NameRu = "Поликапролактам (Жидкость)",
                NameEn = "Polycaprolactam (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "battery_alloy_fluid",
                NameRu = "Аккумуляторный сплав (Жидкость)",
                NameEn = "Battery alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "redstone_fluid",
                NameRu = "Редстоуновая пыль (Жидкость)",
                NameEn = "Redstone (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "red_steel_fluid",
                NameRu = "Красная сталь (Жидкость)",
                NameEn = "Red steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "vanadium_steel_fluid",
                NameRu = "Ванадиевая сталь (Жидкость)",
                NameEn = "Vanadium steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "osmium_fluid",
                NameRu = "Осмий (Жидкость)",
                NameEn = "Osmium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "samarium_fluid",
                NameRu = "Самарий (Жидкость)",
                NameEn = "Samarium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "gallium_arsenide_fluid",
                NameRu = "Арсенид галлия (Жидкость)",
                NameEn = "Gallium arsenide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polytetrafluoroethylene_fluid",
                NameRu = "Политетрафторэтилен (Жидкость)",
                NameEn = "Polytetrafluoroethylene (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "borosilicate_glass_fluid",
                NameRu = "Боросиликатное стекло (Жидкость)",
                NameEn = "Borosilicate glass (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polybenzimidazole_fluid",
                NameRu = "Полибензимидазол (ПБИ) (Жидкость)",
                NameEn = "Polybenzimidazole (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tin_fluid",
                NameRu = "Олово (Жидкость)",
                NameEn = "Tin (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molybdenum_fluid",
                NameRu = "Молибден (Жидкость)",
                NameEn = "Molybdenum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "gold_fluid",
                NameRu = "Золото (Жидкость)",
                NameEn = "Gold (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "neodymium_fluid",
                NameRu = "Неодим (Жидкость)",
                NameEn = "Neodymium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cupronickel_fluid",
                NameRu = "Купроникель (Жидкость)",
                NameEn = "Cupronickel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "glowstone_fluid",
                NameRu = "Светокамень (Жидкость)",
                NameEn = "Glowstone (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "titanium_carbide_fluid",
                NameRu = "Карбид титана (Жидкость)",
                NameEn = "Titanium carbide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "indium_fluid",
                NameRu = "Индий (Жидкость)",
                NameEn = "Indium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "mercury_barium_calcium_cuprate_fluid",
                NameRu = "Купрат ртути бария кальция (Жидкость)",
                NameEn = "Mercury barium calcium cuprate (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "copper_fluid",
                NameRu = "Медь (Жидкость)",
                NameEn = "Copper (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cerium_fluid",
                NameRu = "Церий (Жидкость)",
                NameEn = "Cerium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "brass_fluid",
                NameRu = "Латунь (Жидкость)",
                NameEn = "Brass (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "gallium_fluid",
                NameRu = "Галлий (Жидкость)",
                NameEn = "Gallium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rose_gold_fluid",
                NameRu = "Розовое золото (Жидкость)",
                NameEn = "Rose gold (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polyvinyl_butyral_fluid",
                NameRu = "Поливинибутираль (Жидкость)",
                NameEn = "Polyvinyl butyral (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cobalt_brass_fluid",
                NameRu = "Кобальтовая латунь (Жидкость)",
                NameEn = "Cobalt brass (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uranium_rhodium_dinaquadide_fluid",
                NameRu = "Уран родий динаквада (Жидкость)",
                NameEn = "Uranium rhodium dinaquadide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "niobium_titanium_fluid",
                NameRu = "Ниобий-титан (Жидкость)",
                NameEn = "Niobium titanium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "niobium_fluid",
                NameRu = "Ниобий (Жидкость)",
                NameEn = "Niobium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "red_alloy_fluid",
                NameRu = "Красный сплав (Жидкость)",
                NameEn = "Red_alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "iron_fluid",
                NameRu = "Железо (Жидкость)",
                NameEn = "Iron (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ruthenium_trinium_americium_neutronate_fluid",
                NameRu = "Нейтронат рутения триния америция (Жидкость)",
                NameEn = "Ruthenium trinium americium neutronate (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "vitrified_asbestos_fluid",
                NameRu = "Остеклованный асбест (Жидкость)",
                NameEn = "Vitrified asbestos (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "yttrium_fluid",
                NameRu = "Иттрий (Жидкость)",
                NameEn = "Yttrium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "incoloy_ma_956_fluid",
                NameRu = "Инколой MA-956 (Жидкость)",
                NameEn = "Incoloy MA-956 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "black_steel_fluid",
                NameRu = "Черная сталь (Жидкость)",
                NameEn = "Black steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lead_fluid",
                NameRu = "Свинец (Жидкость)",
                NameEn = "Lead (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "iridium_fluid",
                NameRu = "Иридий (Жидкость)",
                NameEn = "Iridium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "beryllium_fluid",
                NameRu = "Бериллий (Жидкость)",
                NameEn = "Beryllium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lithium_fluid",
                NameRu = "Литий (Жидкость)",
                NameEn = "Lithium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "plutonium_241_fluid",
                NameRu = "Плутоний-241 (Жидкость)",
                NameEn = "Plutonium-241 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uranium_fluid",
                NameRu = "Уран 238 (Жидкость)",
                NameEn = "Uranium 238 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "niobium_nitride_fluid",
                NameRu = "Нитрид ниобия (Жидкость)",
                NameEn = "Niobium nitride (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "electrum_fluid",
                NameRu = "Электрум (Жидкость)",
                NameEn = "Electrum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "duranium_fluid",
                NameRu = "Дюраний (Жидкость)",
                NameEn = "Duranium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cobalt_fluid",
                NameRu = "Кобальт (Жидкость)",
                NameEn = "Cobalt (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steel_fluid",
                NameRu = "Сталь (Жидкость)",
                NameEn = "Steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "manganese_fluid",
                NameRu = "Марганец (Жидкость)",
                NameEn = "Manganese (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rhodium_plated_palladium_fluid",
                NameRu = "Палладий с родиевым покрытием (Жидкость)",
                NameEn = "Rhodium plated palladium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ice_fluid",
                NameRu = "Ледяная слякоть (Жидкость)",
                NameEn = "Ice (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "americium_fluid",
                NameRu = "Америций 243 (Жидкость)",
                NameEn = "Americium 243 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "enriched_naquadah_fluid",
                NameRu = "Обогащенная наквада (Жидкость)",
                NameEn = "Enriched naquadah (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polyethylene_fluid",
                NameRu = "Полиэтилен (Жидкость)",
                NameEn = "Polyethylene (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "polyvinyl_chloride_fluid",
                NameRu = "Поливинил хлорид (Жидкость)",
                NameEn = "Polyvinyl chloride (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "bismuth_fluid",
                NameRu = "Висмут (Жидкость)",
                NameEn = "Bismuth (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nickel_zinc_ferrite_fluid",
                NameRu = "Никель Цинк Феррит (Жидкость)",
                NameEn = "Nickel Zinc Ferrite (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "yttrium_barium_cuprate_fluid",
                NameRu = "Оксид иттрия-бария-меди (Жидкость)",
                NameEn = "Yttrium barium cuprate (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "aluminium_fluid",
                NameRu = "Алюминий (Жидкость)",
                NameEn = "Aluminium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "aluminium_silicate_fluid",
                NameRu = "Алюмосиликат (Жидкость)",
                NameEn = "Aluminium silicate (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uranium_235_fluid",
                NameRu = "Уран-235 (Жидкость)",
                NameEn = "Uranium-235 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naquadah_fluid",
                NameRu = "Наквада (Жидкость)",
                NameEn = "Naquadah (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "glass_fluid",
                NameRu = "Стекло (Жидкость)",
                NameEn = "Glass (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nichrome_fluid",
                NameRu = "Нихром (Жидкость)",
                NameEn = "Nichrome (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tungsten_carbide_fluid",
                NameRu = "Карбид вольфрама (Жидкость)",
                NameEn = "Tungsten carbide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "wrought_iron_fluid",
                NameRu = "Кованое железо (Жидкость)",
                NameEn = "Wrought iron (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "europium_fluid",
                NameRu = "Европий (Жидкость)",
                NameEn = "Europium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tin_alloy_fluid",
                NameRu = "Оловянный сплав (Жидкость)",
                NameEn = "Tin alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lanthanum_fluid",
                NameRu = "Лантан (Жидкость)",
                NameEn = "Lanthanum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "black_bronze_fluid",
                NameRu = "Черная бронза (Жидкость)",
                NameEn = "Black bronze (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "titanium_fluid",
                NameRu = "Титан (Жидкость)",
                NameEn = "Titanium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "silicone_rubber_fluid",
                NameRu = "Силиконовая резина (Жидкость)",
                NameEn = "Silicone rubber (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "blue_steel_fluid",
                NameRu = "Синяя сталь (Жидкость)",
                NameEn = "Blue steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "zinc_fluid",
                NameRu = "Цинк (Жидкость)",
                NameEn = "Zinc (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ruridit_fluid",
                NameRu = "Руридит (Жидкость)",
                NameEn = "Ruridit (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "naquadria_fluid",
                NameRu = "Наквадрия (Жидкость)",
                NameEn = "Naquadria (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "desh_fluid",
                NameRu = "Деш (Жидкость)",
                NameEn = "desh (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tungsten_fluid",
                NameRu = "Вольфрам (Жидкость)",
                NameEn = "Tungsten (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tritanium_fluid",
                NameRu = "Тританий (Жидкость)",
                NameEn = "Tritanium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "osmiridium_fluid",
                NameRu = "Осмистый иридий (Жидкость)",
                NameEn = "Osmiridium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "vanadium_gallium_fluid",
                NameRu = "Ванадий-галлий (Жидкость)",
                NameEn = "Vanadium gallium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "reinforced_epoxy_resin_fluid",
                NameRu = "Укреплённая эпоксидна смола (Жидкость)",
                NameEn = "Reinforced epoxy resin (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "blue_alloy_fluid",
                NameRu = "Синий сплав (Жидкость)",
                NameEn = "Blue alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rubber_fluid",
                NameRu = "Резина (Жидкость)",
                NameEn = "Rubber (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "stainless_steel_fluid",
                NameRu = "Нержавеющая сталь (Жидкость)",
                NameEn = "Stainless steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "darmstadtium_fluid",
                NameRu = "Дармштадтий (Жидкость)",
                NameEn = "Darmstadtium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "invar_fluid",
                NameRu = "Инвар (Жидкость)",
                NameEn = "Invar (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tungsten_steel_fluid",
                NameRu = "Вольфрамовая сталь (Жидкость)",
                NameEn = "Tungsten steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hastelloy_c_276_fluid",
                NameRu = "Хастеллой-C276 (Жидкость)",
                NameEn = "Hastelloy-C276 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "molybdenum_disilicide_fluid",
                NameRu = "Дисилицид молибдена (Жидкость)",
                NameEn = "molybdenum disilicide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "titanium_tungsten_carbide_fluid",
                NameRu = "Вольфрам-титановый карбид (Жидкость)",
                NameEn = "Titanium tungsten carbide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ruthenium_fluid",
                NameRu = "Рутений (Жидкость)",
                NameEn = "Ruthenium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "samarium_iron_arsenic_oxide_fluid",
                NameRu = "Оксид Самария Железа Мышьяка (Жидкость)",
                NameEn = "Samarium Iron Arsenic Oxide (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = " (Жидкость)",
                NameEn = " (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "magnesium_fluid",
                NameRu = "Магний (Жидкость)",
                NameEn = "Magnesium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uranium_triplatinum_fluid",
                NameRu = "Триплатина уран (Жидкость)",
                NameEn = "Uranium triplatinum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rtm_alloy_fluid",
                NameRu = "РВМ сплав (Жидкость)",
                NameEn = "RTM alloy (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "khantal_fluid",
                NameRu = "Кантал (Жидкость)",
                NameEn = "Khantal (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "wax_fluid",
                NameRu = "Воск (Жидкость)",
                NameEn = "Wax (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "platinum_fluid",
                NameRu = "Платина (Жидкость)",
                NameEn = "Platinum (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "maraging_steel_300_fluid",
                NameRu = "Мартенситностареющая сталь 300 (Жидкость)",
                NameEn = "Maraging steel 300 (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "silicon_fluid",
                NameRu = "Кремний (Жидкость)",
                NameEn = "Silicon (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "rhodium_fluid",
                NameRu = "Родий (Жидкость)",
                NameEn = "Rhodium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "trinium_fluid",
                NameRu = "Триниум (Жидкость)",
                NameEn = "Trinium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nickel_fluid",
                NameRu = "Никель (Жидкость)",
                NameEn = "Nickel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "palladium_fluid",
                NameRu = "Палладий (Жидкость)",
                NameEn = "Palladium (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "watertight_steel_fluid",
                NameRu = "Водостойкая сталь (Жидкость)",
                NameEn = "Watertight steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hastelloy_x_fluid",
                NameRu = "Хастеллой-X (Жидкость)",
                NameEn = "Hastelloy-X (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hsla_steel_fluid",
                NameRu = "HSLA сталь (Жидкость)",
                NameEn = "HSLA steel (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hsss_fluid",
                NameRu = "HSS-S (Жидкость)",
                NameEn = "HSS-S (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hsse_fluid",
                NameRu = "HSS-E (Жидкость)",
                NameEn = "HSS-E (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hssg_fluid",
                NameRu = "HSS-G (Жидкость)",
                NameEn = "HSS-G (Liquid)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_ethane_fluid",
                NameRu = "Этан прошедший крекинг паром",
                NameEn = "Steam cracked ethane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dimethylamine_fluid",
                NameRu = "Диметилэтан",
                NameEn = "Dimethylamine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "xenon_fluid",
                NameRu = "Ксенон (газ)",
                NameEn = "Xenon (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ostrum_vapor_fluid",
                NameRu = "Пары острума",
                NameEn = "Ostrum vapor",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "arsenic_steam_fluid",
                NameRu = "Пар (Мышьяк)",
                NameEn = "Steam (Arsenic)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_propane_fluid",
                NameRu = "Пропан прошедший крекинг водородом",
                NameEn = "Hydro cracked propane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitrogen_fluid",
                NameRu = "Азот (газ)",
                NameEn = "Nitrogen (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ammonium_formate_fluid",
                NameRu = "Формиат аммония",
                NameEn = "Ammonium formate",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_propene_fluid",
                NameRu = "Пропен прошедший крекинг водородом",
                NameEn = "Hydro cracked propene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "monochloramine_fluid",
                NameRu = "Хлорамин",
                NameEn = "Monochloramine",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "irradiated_steam_fluid",
                NameRu = "Облученный пар",
                NameEn = "Irradiated steam",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dinitrogen_trioxide_fluid",
                NameRu = "Тетраоксид диазота",
                NameEn = "Dinitrogen tetroxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "propane_fluid",
                NameRu = "Пропан",
                NameEn = "Propane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dense_ostrum_vapor_fluid",
                NameRu = "Плотные пары острума",
                NameEn = "Dense ostrum vapor",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_ethane_fluid",
                NameRu = "Этан прошедший крекинг водородом",
                NameEn = "Hydro cracked ethane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "neon_fluid",
                NameRu = "Неон (газ)",
                NameEn = "Neon (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "regolith_vapor_fluid",
                NameRu = "Реголитовый пар",
                NameEn = "Regolith vapor",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ethylene_fluid",
                NameRu = "Этилен",
                NameEn = "Ethylene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "radon_fluid",
                NameRu = "Радон (газ)",
                NameEn = "Radon (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrogen_sulfide_fluid",
                NameRu = "Сероводород",
                NameEn = "Hydrogen sulfide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "air_fluid",
                NameRu = "Земной воздух",
                NameEn = "Air",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "butane_fluid",
                NameRu = "Бутан",
                NameEn = "Butane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "methane_fluid",
                NameRu = "Метан (газ)",
                NameEn = "Methane (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_hydro_cracked_gas_fluid",
                NameRu = "Нефтяной газ прошедший легкий крекинг водородом",
                NameEn = "Lightly hydro cracked gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "cumene_fluid",
                NameRu = "Кумола",
                NameEn = "Cumene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfur_dioxide_fluid",
                NameRu = "Диоксид серы",
                NameEn = "Sulfur dioxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_butene_fluid",
                NameRu = "Бутен прошедший крекинг паром",
                NameEn = "Steam cracked butene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "helium_fluid",
                NameRu = "Гелий (газ)",
                NameEn = "Helium (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_ethylene_fluid",
                NameRu = "Этилен прошедший крекинг паром",
                NameEn = "Steam cracked ethylene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "depleted_uranium_hexafluoride_fluid",
                NameRu = "Обедненный гексофторид урана",
                NameEn = "Depleted uranium hexafluoride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "deuterium_fluid",
                NameRu = "Дейтерий (газ)",
                NameEn = "Deuterium (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tetrafluoroethylene_fluid",
                NameRu = "Тетрафторэтилен",
                NameEn = "Tetrafluoroethylene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitrous_oxide_fluid",
                NameRu = "Оксид азота",
                NameEn = "Nitrous oxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_butane_fluid",
                NameRu = "Бутан прошедший крекинг паром",
                NameEn = "Steam cracked butane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "krypton_fluid",
                NameRu = "Криптон",
                NameEn = "Krypton",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfuric_gas_fluid",
                NameRu = "Серный газ",
                NameEn = "Sulfuric gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitrogen_dioxide_fluid",
                NameRu = "Диоксид азота",
                NameEn = "Nitrogen dioxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "argon_fluid",
                NameRu = "Аргон (газ)",
                NameEn = "Argon (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_butadiene_fluid",
                NameRu = "Бутадиен прошедший крекинг водородом",
                NameEn = "Hydro cracked butadiene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_propane_fluid",
                NameRu = "Пропан прошедший крекинг паром",
                NameEn = "Steam cracked propane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "radioactive_waste_fluid",
                NameRu = "Радиоактивные продукты",
                NameEn = "Radioactive waste",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ammonia_fluid",
                NameRu = "Аммиак",
                NameEn = "Ammonia",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "propene_fluid",
                NameRu = "Пропен",
                NameEn = "Propene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitrobenzene_fluid",
                NameRu = "Нитробензол",
                NameEn = "Nitrobenzene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "butadiene_fluid",
                NameRu = "Бутадиен",
                NameEn = "Butadiene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "chlorine_fluid",
                NameRu = "Хлор (газ)",
                NameEn = "chlorine (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_hydro_cracked_gas_fluid",
                NameRu = "Нефтной газ прошедший тяжелый крекинг водородом",
                NameEn = "Severely hydro cracked gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrogen_iodide_fluid",
                NameRu = "Йодоводород",
                NameEn = "Hydrogen iodide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_ethylene_fluid",
                NameRu = "Этилен прошедший крекинг водородом",
                NameEn = "Hydro cracked ethylene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "sulfur_trioxide_fluid",
                NameRu = "Триоксид серы",
                NameEn = "Sulfur trioxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_fluid",
                NameRu = "Пар",
                NameEn = "Steam",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "vinyl_chloride_fluid",
                NameRu = "Винилхлорид",
                NameEn = "Vinyl chloride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitrosyl_chloride_fluid",
                NameRu = "Хлорид нитрозила",
                NameEn = "Nitrosyl chloride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "severely_steam_cracked_gas_fluid",
                NameRu = "Нефтяной газ прошедший жесткий крекинг паром",
                NameEn = "Severely steam cracked gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "fluorene_fluid",
                NameRu = "Фтор (газ)",
                NameEn = "Fluorene (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "nitric_oxide_fluid",
                NameRu = "Оксид азота(II)",
                NameEn = "Nitric oxide(II)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "radioactive_steam_fluid",
                NameRu = "Радиоактивный пар",
                NameEn = "Radioactive steam",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightweight_ostrum_vapor_fluid",
                NameRu = "Легкие пары острума",
                NameEn = "Lightweight ostrum vapor",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "coal_gas_fluid",
                NameRu = "Угольный газ",
                NameEn = "Coal gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrogen_cyanide_fluid",
                NameRu = "Синильная кислота",
                NameEn = "Hydrogen cyanide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "oxygen_fluid",
                NameRu = "Кислород (газ)",
                NameEn = "Oxygen (gas)",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "helium_3_fluid",
                NameRu = "Гелий-3",
                NameEn = "Helium-3",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "lightly_steam_cracked_gas_fluid",
                NameRu = "Нефтяной газ прошедший легкий крекинг паром",
                NameEn = "Lightly steam cracked gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_butene_fluid",
                NameRu = "Бутен прошедший крекинг водородом",
                NameEn = "Hydro cracked butene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "refinery_gas_fluid",
                NameRu = "Нефтяной газ",
                NameEn = "Refinery gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_propene_fluid",
                NameRu = "Пропен прошедший крекинг паром",
                NameEn = "Steam cracked propene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "steam_cracked_butadiene_fluid",
                NameRu = "Бутадиен прошедший крекинг паром",
                NameEn = "Steam cracked butadiene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "chloromethane_fluid",
                NameRu = "Хлорметан",
                NameEn = "Chloromethane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "carbon_dioxide_fluid",
                NameRu = "Двуокись углерода",
                NameEn = "Carbon dioxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "tritium_fluid",
                NameRu = "Тритий (газ)",
                NameEn = "Tritium",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dimethyldichlorosilane_fluid",
                NameRu = "Диметилдихлорсилана",
                NameEn = "Dimethyldichlorosilane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "enriched_uranium_hexafluoride_fluid",
                NameRu = "Обогащенный гексафторид урана",
                NameEn = "Enriched uranium hexafluoride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydrogen_fluid",
                NameRu = "Водород (газ)",
                NameEn = "Hydrogen",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "hydro_cracked_butane_fluid",
                NameRu = "Бутан прошедший крекинг водородом",
                NameEn = "Hydro cracked butane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "uranium_hexafluoride_fluid",
                NameRu = "Гексафторид урана",
                NameEn = "Uranium hexafluoride",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "butene_fluid",
                NameRu = "Бутен",
                NameEn = "Butene",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "wood_gas_fluid",
                NameRu = "Древесный газ",
                NameEn = "Wood gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "dense_steam_fluid",
                NameRu = "ПВД",
                NameEn = "Dense steam",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "ethane_fluid",
                NameRu = "Этан",
                NameEn = "Ethane",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "natural_gas_fluid",
                NameRu = "Природный газ",
                NameEn = "Natural gas",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "carbon_monooxide_fluid",
                NameRu = "Монооксид углерода",
                NameEn = "Zerbin monooxide",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            new GameItem
            {
                Id = "_fluid",
                NameRu = "",
                NameEn = "",
                Type = "Жидкость",
                Tag = "forge:fluid"
            },
            // ==========================================
            //                Очищенные руды
            // ==========================================
            new GameItem
            {
                Id = "purified_chalcopyrite_ore",
                NameRu = "Халькопирит (Очищенная руда)",
                NameEn = "Chalcopyrite (Purified ore)",
                Type = "Очищенная руда",
                Tag = "forge:purified_ores"
            },
            new GameItem
            {
                Id = "purified_bornite_ore",
                NameRu = "Борнит (Очищенная руда)",
                NameEn = "Bornite (Purified ore)",
                Type = "Очищенная руда",
                Tag = "forge:purified_ores"
            },
            new GameItem
            {
                Id = "purified_chalcocite_ore",
                NameRu = "Халькозин (Очищенная руда)",
                NameEn = "Chalcocite (Purified ore)",
                Type = "Очищенная руда",
                Tag = "forge:purified_ores"
            },
            new GameItem
            {
                Id = "purified_tetrahedrite_ore",
                NameRu = "Тетраэдрит (Очищенная руда)",
                NameEn = "Tetrahedrite (Purified ore)",
                Type = "Очищенная руда",
                Tag = "forge:purified_ores"
            },
            new GameItem
            {
                Id = "purified_pentlandite_ore",
                NameRu = "Пентландит (Очищенная руда)",
                NameEn = "Pentlandite (Purified ore)",
                Type = "Очищенная руда",
                Tag = "forge:purified_ores"
            },
            new GameItem
            {
                Id = "purified_cooperite_ore",
                NameRu = "Куперит (Очищенная руда)",
                NameEn = "Cooperite (Purified ore)",
                Type = "Очищенная руда",
                Tag = "forge:purified_ores"
            },

            // ==========================================
            //             Интегральные схемы
            // ==========================================
            new GameItem
            {
                Id = "programmed_circuit_1",
                NameRu = "Интегральная схема 1",
                NameEn = "Programmed circuit 1",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_1.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_2",
                NameRu = "Интегральная схема 2",
                NameEn = "Programmed circuit 2",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_2.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_3",
                NameRu = "Интегральная схема 3",
                NameEn = "Programmed circuit 3",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_3.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_4",
                NameRu = "Интегральная схема 4",
                NameEn = "Programmed circuit 4",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_4.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_5",
                NameRu = "Интегральная схема 5",
                NameEn = "Programmed circuit 5",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_5.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_6",
                NameRu = "Интегральная схема 6",
                NameEn = "Programmed circuit 6",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_6.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_7",
                NameRu = "Интегральная схема 7",
                NameEn = "Programmed circuit 7",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_7.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_8",
                NameRu = "Интегральная схема 8",
                NameEn = "Programmed circuit 8",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_8.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_9",
                NameRu = "Интегральная схема 9",
                NameEn = "Programmed circuit 9",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_9.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_10",
                NameRu = "Интегральная схема 10",
                NameEn = "Programmed circuit 10",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_10.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_11",
                NameRu = "Интегральная схема 11",
                NameEn = "Programmed circuit 11",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_11.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_12",
                NameRu = "Интегральная схема 12",
                NameEn = "Programmed circuit 12",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_12.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_13",
                NameRu = "Интегральная схема 13",
                NameEn = "Programmed circuit 13",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_13.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_14",
                NameRu = "Интегральная схема 14",
                NameEn = "Programmed circuit 14",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_14.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_15",
                NameRu = "Интегральная схема 15",
                NameEn = "Programmed circuit 15",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_15.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_16",
                NameRu = "Интегральная схема 16",
                NameEn = "Programmed circuit 16",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_16.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_17",
                NameRu = "Интегральная схема 17",
                NameEn = "Programmed circuit 17",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_17.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_18",
                NameRu = "Интегральная схема 18",
                NameEn = "Programmed circuit 18",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_18.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_19",
                NameRu = "Интегральная схема 19",
                NameEn = "Programmed circuit 19",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_19.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_20",
                NameRu = "Интегральная схема 20",
                NameEn = "Programmed circuit 20",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_20.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_21",
                NameRu = "Интегральная схема 21",
                NameEn = "Programmed circuit 21",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_21.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_22",
                NameRu = "Интегральная схема 22",
                NameEn = "Programmed circuit 22",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_22.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_23",
                NameRu = "Интегральная схема 23",
                NameEn = "Programmed circuit 23",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_23.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_24",
                NameRu = "Интегральная схема 24",
                NameEn = "Programmed circuit 24",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_24.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_25",
                NameRu = "Интегральная схема 25",
                NameEn = "Programmed circuit 25",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_25.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_26",
                NameRu = "Интегральная схема 26",
                NameEn = "Programmed circuit 26",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_26.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_27",
                NameRu = "Интегральная схема 27",
                NameEn = "Programmed circuit 27",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_27.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_28",
                NameRu = "Интегральная схема 28",
                NameEn = "Programmed circuit 28",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_28.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_29",
                NameRu = "Интегральная схема 29",
                NameEn = "Programmed circuit 29",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_29.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_30",
                NameRu = "Интегральная схема 30",
                NameEn = "Programmed circuit 30",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_30.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_31",
                NameRu = "Интегральная схема 31",
                NameEn = "Programmed circuit 31",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_31.png"
            },
            new GameItem
            {
                Id = "programmed_circuit_32",
                NameRu = "Интегральная схема 32",
                NameEn = "Programmed circuit 32",
                Type = "Очищенная руда",
                Tag = "gtceu:programmed_circuit",
                IconPath = "images/items/programmed_circuit_32.png"
            },
            // ==========================================
            //             Интегральные схемы
            // ==========================================
            new GameItem
            {
                Id = "ulv_universal_circuit",
                NameRu = "Универсальная схема ULV",
                NameEn = "Universal circuit ULV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/ulv.gif"
            },
            new GameItem
            {
                Id = "lv_universal_circuit",
                NameRu = "Универсальная схема LV",
                NameEn = "Universal circuit LV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/lv.gif"
            },
            new GameItem
            {
                Id = "mv_universal_circuit",
                NameRu = "Универсальная схема MV",
                NameEn = "Universal circuit MV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/mv.gif"
            },
            new GameItem
            {
                Id = "hv_universal_circuit",
                NameRu = "Универсальная схема HV",
                NameEn = "Universal circuit HV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/hv.gif"
            },
            new GameItem
            {
                Id = "ev_universal_circuit",
                NameRu = "Универсальная схема EV",
                NameEn = "Universal circuit EV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/ev.gif"
            },
            new GameItem
            {
                Id = "iv_universal_circuit",
                NameRu = "Универсальная схема IV",
                NameEn = "Universal circuit IV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/iv.gif"
            },
            new GameItem
            {
                Id = "luv_universal_circuit",
                NameRu = "Универсальная схема LuV",
                NameEn = "Universal circuit LuV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/luv.gif"
            },
            new GameItem
            {
                Id = "zpm_universal_circuit",
                NameRu = "Универсальная схема ZPM",
                NameEn = "Universal circuit ZPM",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/zpm.gif"
            },
            new GameItem
            {
                Id = "uv_universal_circuit",
                NameRu = "Универсальная схема UV",
                NameEn = "Universal circuit UV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/uv.gif"
            },
            new GameItem
            {
                Id = "uhv_universal_circuit",
                NameRu = "Универсальная схема UHV",
                NameEn = "Universal circuit UHV",
                Type = "Очищенная руда",
                Tag = "gtceu:circuits",
                IconPath = "images/tiers/uhv.gif"
            },

        }
    };

    public List<GameItem> GetByModpack(string modpackId)
    {
        return _items.TryGetValue(modpackId, out var items) ? items : new();
    }

    public List<GameItem> Search(string modpackId, string query)
    {
        var items = GetByModpack(modpackId);
        if (string.IsNullOrWhiteSpace(query))
            return items;

        return items.Where(i =>
            i.NameRu.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.NameEn.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.Tag.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.Type.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            i.Id.Contains(query, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public GameItem? GetById(string modpackId, string itemId)
    {
        return GetByModpack(modpackId).FirstOrDefault(i => i.Id == itemId);
    }
}