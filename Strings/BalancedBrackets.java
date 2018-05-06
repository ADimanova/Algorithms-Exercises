import java.util.*;
class Solution{
   
   public static void main(String []argh)
   {
      Scanner sc = new Scanner(System.in);
      Stack<String> stack = new Stack<String>();
      HashMap<String, String> couples = new HashMap<String, String>();
      couples.put(")", "(");
      couples.put("}", "{");
      couples.put("]", "[");
       
      while (sc.hasNext()) {
         String input=sc.next();
         String[] brackets = input.split("");
         Boolean isValid = true;
         for(String bracket : brackets) {                              
             if(!couples.containsKey(bracket)) {
                stack.push(bracket);
             }
             else if(stack.empty()) {
                isValid = false;  
                break;
             } 
             else {
                String opening = stack.pop();
                 
                if(!opening.equals(couples.get(bracket))) {
                    isValid = false;  
                    break;
                }
             }
         }
         
         if(isValid && stack.empty())
         {
             System.out.println("true");
         }
         else {
            System.out.println("false");             
         }
         
         stack.clear();
      }
      
   }
}
