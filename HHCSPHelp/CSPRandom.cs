using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HHCSPHelp
{
    internal class CSPRandom
    {
        public CSPRandom(int max)
        {
            _maxValue = max;
        }

        private int _maxValue;

        /// <summary>
        /// Return "大于等于 0 小于 max"
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public int Next()
        {
            Random r = new Random(GetGUIDInt());
            try
            {              
                return r.Next(_maxValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int GetGUIDInt()
        {
            return System.Math.Abs(Guid.NewGuid().GetHashCode());
        }
    }
}
