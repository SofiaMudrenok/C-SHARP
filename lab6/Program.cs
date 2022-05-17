using System.Linq;
using System.Collections.Generic;    
using System;
namespace Namespace {
    public static class Module {
        
        public class TMatrix {
            
            public TMatrix(object n, params object [] args) {
                this.n = n;
                this.matrix = map(list, args).ToList();
            }
            
            public virtual object input_matrix(params object [] args) {
                this.matrix = map(list, args).ToList();
            }
            
            public virtual object input_n(object n) {
                this.n = n;
            }
            
            public virtual object print_matrix() {
                return this.matrix;
            }
            
            public virtual object print_n() {
                return this.n;
            }
            
            public virtual object print_all() {
                return "{0}\n{1}".format(this.n, this.matrix);
            }
            
            public object el {
                get {
                    var d = new List<object>();
                    foreach (var i in Enumerable.Range(0, this.n)) {
                        d.extend(this.matrix[i]);
                    }
                    return d;
                }
            }
            
            public virtual object max_in_matrix() {
                return max(this.el);
            }
            
            public virtual object min_in_matrix() {
                return min(this.el);
            }
            
            public virtual object sum_el() {
                return this.el.Sum();
            }
        }
        
        public static object f = TMatrix(2, (1, 2), (3, 4));
    }
}
