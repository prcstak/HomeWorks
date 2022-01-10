using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using databaseApp.DataBase;

namespace databaseApp.Service
{
    public class GetRandomCreature: IDataGet
    {
        
        private Context db { get; set; }
        public GetRandomCreature (Context context)
        {
            db = context;
        }
        
        public override string DataGet()
        {
            var r = new Random();
            var maxId = db.Creature.Max(id => id.Id);
            var id = r.Next(1, maxId+1);
            var creature = db.Creature.First(c => c.Id == id);
            var result = JsonSerializer.Serialize(creature);
            return result;
        }
    }
}