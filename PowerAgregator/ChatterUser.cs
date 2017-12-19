using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerAgregator
{
    public class Dialog
    {
        public double Rate;
        public double Offence;
        public bool Active;
        public DateTime Min;
        public DateTime Max;
    }
    public class ChatterUser
    {
        /// <summary>
        /// Display Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id of reffered chat plugin
        /// </summary>
        public IChatPlugin Chatter { get; set; }
        /// <summary>
        /// Id of user, user should be able to determinated in plugin by this
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Any additional user data that can be required by plugin
        /// </summary> 
        public object UserAdditionalSpec { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Message> Messages { get; set; }

        public double ActivityRate;
        public TimeSpan ResponseTime;

        const long SingleDay = 864000000000L;
        const long Week = 864000000000L;

        public void ClculateHistoricalRates()
        {
            var Date = DateTime.Now;
            if (Messages == null || !Messages.Any()) return;
            var msgs = Messages.OrderBy(x => x.Time).ToArray();
            var splitted = GetDialogs(msgs).ToList();

            //Clac date smaller then x.Max with period 1 day (864000000000L tiks)
            var Daily = splitted.Where(x => Date.AddDays((splitted[0].Max.Ticks - Date.Ticks) / 864000000000L - 1L) > x.Min);
            //6048000000000L - one week tiks;
            var Weekly = splitted.Where(x => Date.AddDays((splitted[0].Max.Ticks - Date.Ticks) / 6048000000000L * 7L - 7L) > x.Min);

            double ResponseTiks = 0;
            ActivityRate = 0;

            if (Daily.Any())
            {
                ResponseTiks += Daily.Average(x => x.Active ? 1 : -1);
                ActivityRate += Daily.Average(x => x.Rate);
            }
            if (Weekly.Any())
            {
                ResponseTiks += Weekly.Average(x => x.Active ? 2 : -2);
                ActivityRate += Weekly.Average(x => x.Rate);
            }
            if (ResponseTiks == 0 && !Daily.Any() && !Weekly.Any()) ResponseTiks = 100000000L;//3000000000L;
            ResponseTime = new TimeSpan((long)ResponseTiks);
        }

        private static IEnumerable<Dialog> GetDialogs(Message[] msgs)
        {
            List<long> times = new List<long>();
            if (msgs.Length < 2) return new List<Dialog>();
            for (int i = 1; i < msgs.Length; i++)
            {
                times.Add(msgs[i].Time.Ticks - msgs[i - 1].Time.Ticks);
            }
            var rate = times.Average();
            var offence = 2 * Math.Sqrt(times.Average(x => (x - rate) * (x - rate)));
            var splitIndecies = times.Select((x, i) => Math.Abs(rate - x) > offence ? i : -1).Where(z => z != -1);
            IEnumerable<Dialog> results = new List<Dialog>();
            if (splitIndecies.Any())
            {
                int StartIndex = -1;
                foreach (int index in splitIndecies)
                {
                    results = results.Concat(GetDialogs(msgs.Where((x, i) => i > StartIndex && i <= index).ToArray()));
                    StartIndex = index;
                }
                results = results.Concat(GetDialogs(msgs.Where((x, i) => i > StartIndex && i <= int.MaxValue).ToArray()));
                return results;
            }
            else
            {
                (results as List<Dialog>).Add(new Dialog()
                {
                    Rate = rate,
                    Offence = offence,
                    Active = msgs.Any(x => x.Recived),
                    Min = msgs.First().Time.AddTicks(-(long)rate),
                    Max = msgs.Last().Time.AddTicks((long)rate + 10)
                });
                return results;
            }
        }

        public AgregatorUser AgregatorUser { get; set; }

        public override string ToString()
        {
            return $"[{Chatter.Id}] {Name}";
        }


        public ChatterUser() { }
        public ChatterUser(ChatterUserData data, Core core)
        {
            this.Name = data.Name;
            this.UserId = data.UserId;
            this.Chatter = core.Chatters.First(x => x.Id == data.ChatterId);
            if (data.AgregatorUserId != null)
            {
                this.AgregatorUser = core.Users.First(x => x.Name == data.AgregatorUserId);
                this.AgregatorUser.Chatters.Add(this);
            }
        }

        public ChatterUserData StoreData()
        {
            return new ChatterUserData
            {
                AgregatorUserId = AgregatorUser != null ? AgregatorUser.Name : null,
                ChatterId = Chatter.Id,
                Name = Name,
                UserId = UserId
            };
        }
    }
}