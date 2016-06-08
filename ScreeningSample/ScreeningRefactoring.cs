using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreeningSample
{
    public class ScreeningRefactoring
    {
        public int AMethod(bool first, bool second, bool third)
        {
            int OptionOne = 1, OptionTwo = 2;

            //Step 0: Initial version
            //if (!first)
            //{
            //    if (second)
            //    {
            //        if (third)
            //        {
            //            return OptionOne;   // case	1: false true true
            //        }
            //        else if (!second)
            //        {
            //            return OptionTwo;   // case 2: !first && second && !third && !second --- invalid
            //        }
            //        else
            //        {
            //            return OptionOne;   // case 3: false true false
            //        }
            //    }
            //    else
            //    {
            //        return OptionOne;       // case 4: false false true || false false false
            //    }
            //}
            //else if (!third)
            //{
            //    if (!second)
            //    {
            //        return OptionTwo;       // case 5: true false false
            //    }
            //}
            //else if (!second)
            //{
            //    return OptionTwo;           // case 6: true false true
            //}
            //if (!(third || !second))
            //{
            //    return OptionTwo;           // case 7: true true false
            //}
            //return OptionOne;				// case 8: true true true

            //Step 1: Delete invalid case 2       
            //if (!first)
            //{
            //    if (second)
            //    {
            //        if (third)
            //        {
            //            return OptionOne;   // case	1: false true true
            //        }
            //        else
            //        {
            //            return OptionOne;   // case 3: false true false
            //        }
            //    }
            //    else
            //    {
            //        return OptionOne;       // case 4: false false true || false false false
            //    }
            //}
            //else if (!third)
            //{
            //    if (!second)
            //    {
            //        return OptionTwo;       // case 5: true false false
            //    }
            //}
            //else if (!second)
            //{
            //    return OptionTwo;           // case 6: true false true
            //}
            //if (!(third || !second))
            //{
            //    return OptionTwo;           // case 7: true true false
            //}
            //return OptionOne;				// case 8: true true true

            //Step 2: Combine case 1 and case 3        
            //if (!first)
            //{
            //    if (second)
            //    {
            //        return OptionOne;   // case	1: false true true
            //    }
            //    else
            //    {
            //        return OptionOne;       // case 4: false false true || false false false
            //    }
            //}
            //else if (!third)
            //{
            //    if (!second)
            //    {
            //        return OptionTwo;       // case 5: true false false
            //    }
            //}
            //else if (!second)
            //{
            //    return OptionTwo;           // case 6: true false true
            //}
            //if (!(third || !second))
            //{
            //    return OptionTwo;           // case 7: true true false
            //}
            //return OptionOne;				// case 8: true true true        

            //Step 3: Combine case 1 and case 4        
            //if (!first)
            //{
            //    return OptionOne;   // case	1: false true true
            //}
            //else if (!third)
            //{
            //    if (!second)
            //    {
            //        return OptionTwo;       // case 5: true false false
            //    }
            //}
            //else if (!second)
            //{
            //    return OptionTwo;           // case 6: true false true
            //}
            //if (!(third || !second))
            //{
            //    return OptionTwo;           // case 7: true true false
            //}
            //return OptionOne;				// case 8: true true true

            //Step 4: Reduce        
            //if (!first)
            //{
            //    return OptionOne;   // case	1: false true true
            //}

            //if (!third && !second)
            //{
            //    return OptionTwo;       // case 5: true false false
            //}

            //if (!second)
            //{
            //    return OptionTwo;           // case 6: true false true
            //}

            //if (!third && second)
            //{
            //    return OptionTwo;           // case 7: true true false
            //}

            //return OptionOne;				// case 8: true true true      

            //Step 5: Combine case 5, case 6 and case 7        
            //if (!first)
            //{
            //    return OptionOne;   // case	1: false true true
            //}

            //if (!third && !second || !second || !third && second)
            //{
            //    return OptionTwo;           // case 7: true true false
            //}

            //return OptionOne;				// case 8: true true true    

            //Step 6: Simplify case 7        
            //if (!first)
            //{
            //    return OptionOne;   // case	1: false true true
            //}

            //if (!third || !second)
            //{
            //    return OptionTwo;           // case 7: true true false
            //}
            //return OptionOne;				// case 8: true true true    

            //Step 7:  rewrite case 7
            //if (first && (!third || !second))
            //{
            //    return OptionTwo;           // case 7: true true false
            //}

            //if (!first)
            //{
            //    return OptionOne;   // case	1: false true true
            //}
            //return OptionOne;				// case 8: true true true

            //Step 8:  reduce
            //if (first && (!third || !second))
            //{
            //    return OptionTwo;           // case 7: true true false
            //}
            //else
            //{
            //    return OptionOne;   // case	1: false true true
            //}

            //Step 9:  Simplify				
            return first && !third || first && !second ? OptionTwo : OptionOne;

        }
    }
}
