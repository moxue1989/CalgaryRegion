using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CalgaryHacks.EventDtos;

namespace CalgaryHacks.Apis
{
    public class MeetupGroupsToSig
    {
        
        public const String SIG_ID = "240809776";
        public static Dictionary<String, String> GroupUrlNameToSigDict = new Dictionary<String, String>()
        {
            {"Calgary-Agile-Methods-User-Group", "c27e2e9350864f824a340e71bf0f99c72f9947c9"},
            {"ATB-Entrepreneur-Centre-YYC", "a3a95af9aeedbe25c37791764d429c6a357b25c4"},
            {"Calgary-R-User-Group", "cd42ebb76cf96f60e0bfc6f6416cb7fec9013df9"},
            {"py-yyc", "b09642379894d7859035284a607ad6e46dca5daf"},
            {"Startup-Calgary", "b9f1175fb5782299b4af260e0dedd92161a4e8fb"},
            {"Data-for-Good-Calgary", "71502f61f3ed41d3555f932f9098449e8eaa7106"},
            {"ShowUpAndPlaySports", "488f966cedf8f317fe978cf5b3cafa35ccc5ab26"},
            {"HackerNestCAL", "30e75efbbce1a2928e2f3173825f133426c3c6cf"},
            {"Calgary-Music-Meetup", "bdc6845a35f348cf19e443c70d7c244de4b97af9"},
            {"CalgaryWeekendWarriors", "68d0af6f30dba968254d02c4c3d7c7a44a61fbce"},
            {"BioHackYYC", "e57f419f4e6f794cf7e305f92e5bf2dee1266d97"},
            {"pxandpints", "f249d75041e7e8dd91329e2f1ec1c9431ed12fac"},
            {"Calgary-GoGeomatics-Canada-Monthly-Networking-Social","d496336ee2fe534c1552bd204c7608a4114b14d2"},
            {"New-Tech-Meetup","f304074cf6bfbf706b4db6acde90e37de53f9d19"},
            {"Strangers-Lets-Be-Friends","79326285c01fe02cfb86a087d380a4e508b756c0"},
            {"YYC-Rb","ed6e4b6353de259fdfb0e83279e745ef89d81cdb"},
            {"Easy-Hiking-in-Canadas-Parks","2c76b9cc403bb11e20a48eac8cae9641d9f01e7c"},
            {"Maker-Creative-Workshops-in-Calgary","5e58627c4cc855ab4a3e40cb821f4bb9ae1e5e2e"},
            {"Solar-Power-and-Sustainability","a5f52d2ccd11491017212fc342ad709c06db411d"},
            {"Calgary-Microsoft-User-Group","d70dcf1b54855a4c914323ba9ceb62d99b810242"},
            {"PyData-Calgary","de98df7cb42958152305b324463876fff0fc88e7"},
            {"AndroidDevelopersCalgary","51facbd388400634f622764ec6e69f956de9cd82"},
            {"Calgary-AWS-User-Group","b2095e08492f97bbb0e4bf915a8082c8ee5258e2"},
            {"Calgary-Outdoor-Recreation-Association-CORA","9f57e36b6993b13bb18c190a88f9b97c669df175"},
            {"Calgary-Hiking-and-Scrambling-Meetup","0e4e8dca716885c3d42c14adb9c060241bb711db"}
        };
    }
}