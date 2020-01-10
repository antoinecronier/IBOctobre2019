using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTP3.Entities
{
    public class Service : EntityBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private long serviceId;
        private string name;
        private string description;
        #endregion

        #region Properties
        public long ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Service()
        {
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public override object Copy()
        {
            throw new NotImplementedException();
        }

        public override void CopyFrom(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Events
        #endregion
    }
}
