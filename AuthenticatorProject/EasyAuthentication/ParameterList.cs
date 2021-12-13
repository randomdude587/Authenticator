using System.Collections.Generic;
using System.Collections;

namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// A list of parameters.
    /// </summary>
    public class ParameterList : IEnumerable<Parameter> {
        /// <summary>
        /// Access to the list of parameters.
        /// </summary>
        public LinkedList<Parameter> Parameters { get; set; }
        /// <summary>
        /// Returns how many parameters are currently in the list.
        /// </summary>
        public int Count {
            get { return this.Parameters.Count; }
        }

        /// <summary>
        /// Instantiate a new empty list of parameters.
        /// </summary>
        public ParameterList() {
            this.Parameters = new LinkedList<Parameter>();
        }

        // Enable enumeration on the list.
        public IEnumerator<Parameter> GetEnumerator() {
            foreach (Parameter val in Parameters) {
                yield return val;
            }
        }

        IEnumerator<Parameter> IEnumerable<Parameter>.GetEnumerator() {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns all the parameters in the list that correspond to the given attribute.
        /// </summary>
        /// <param name="attribute">The attribute used to filter.</param>
        /// <returns>The list of parameters.</returns>
        public ParameterList GetParametersByAttribute(Attribute attribute) {
            ParameterList _l = new ParameterList();
            foreach(Parameter _p in this) {
                if (_p.Attribute == attribute)
                    _l.Parameters.AddLast(_p);
            }
            return _l;
        }

        /// <summary>
        /// Goes through the list and returns the first instance of parameter that corresponds to the attribute.
        /// If none is found, returns null.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns>An instance of Parameter with the corresponding attribute if one is found, null otherwise.</returns>
        public Parameter GetFirstParameterByAttribute(Attribute attribute) {
            foreach (Parameter _p in this) {
                if (_p.Attribute == attribute)
                    return _p;
            }
            return null;
        }
    }
}
