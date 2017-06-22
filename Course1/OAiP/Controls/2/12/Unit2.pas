unit Unit2;

interface
type
   tinf=char;

   Psel=^sel;
   sel=record
      inf:Tinf;
      a:psel;
   end;

   Tstack=class(Tobject)
      sp,sp1:Psel;
      constructor create;
      procedure add1(inf:Tinf);
      procedure read1(var Inf:Tinf);
   end;


   Tzad=class(Tobject)
      zn:array['a'..'ÿ'] of extended;
      stack:Tstack;
      procedure OBP(var si,sp:string);
   end;



implementation
constructor Tstack.create;
begin
   inherited create;
   sp1:=nil;
end;



procedure Tstack.add1;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=sp1;
   sp1:=sp;
end;


procedure Tstack.read1;
begin
   sp:=sp1;
   inf:=sp.inf;
   sp1:=sp.a;
   dispose(sp);
end;


procedure Tzad.OBP;
   function prior(ch:char):byte;
   begin
      case ch of
         '(',')': prior:=0;
         '+','-': prior:=1;
         '*','/': Prior:=2;
         '^': prior:=3;
      end;
   end; //prior

var pc:0..3; i:word;
   ch,ch1:char;
begin
   stack:=Tstack.create;
   sp:='';
   for i:=1 to length(si) do
   begin
      ch:=si[i];
      if not(ch in [')','(','+','-','*','/','^']) then
         sp:=sp+ch
      else
      begin
         if stack.sp1=nil then
            stack.add1(ch)

         else if ch='(' then
            stack.add1(ch)

            else if ch=')' then
            begin
               stack.read1(ch);
               while ch<>'(' do
               begin
                  sp:=sp+ch;
                  stack.read1(ch);
               end;
            end

               else
               begin
                  pc:=prior(ch);
                  while (stack.sp1<>nil) and (pc<=prior(stack.sp1.inf)) do
                  begin
                     stack.read1(ch1);
                     sp:=sp+ch1;
                  end;
                  stack.add1(ch);
               end;
      end;
   end;
   while stack.sp1<>nil do
   begin
      stack.read1(ch);
      sp:=sp+ch;
   end;

end;




end.
 