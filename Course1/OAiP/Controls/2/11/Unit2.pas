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
      function AV(sp:string):extended;
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



function Tzad.AV;
var ch,chr,ch1,ch2:char;
   op1,op2,rez:extended;
   i:word;
begin
   stack:=tstack.create;
   chr:=succ('z');
   for i:=1 to length(sp) do
   begin
      ch:=sp[i];
      if not(ch in ['+','-','*','/','^']) then
         stack.add1(ch)
      else
      begin
         stack.read1(ch2);
         stack.read1(ch1);
         op1:=zn[ch1];
         op2:=zn[ch2];
         case ch of
            '+': rez:=op1+op2;
            '-': rez:=op1-op2;
            '*': rez:=op1*op2;
            '/': rez:=op1/op2;
            '^': rez:=exp(op2*ln(op1));
         end;
         zn[chr]:=rez;
         stack.add1(chr);
         inc(chr);
      end;
   end;
   result:=rez;
   stack.Free;
end;


end.
 