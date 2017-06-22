unit Unit3;

interface

Uses Unit2, Math;

Type
TClass = class(TObject)
         mszn: array ['à'..'ÿ'] of extended;
         Steck:TSteck;
         function AV(strp:string):extended;
end;

implementation

function TClass.AV(strp:string):extended;
var
ch,ch1,ch2:char;
op1,op2,rez:extended;
i:word;
begin
Steck:=TSteck.create();
for i:=1 to Length(strp) do
 begin
  ch:=strp[i];
  if not (ch in ['(',')','+','-','*','/','^']) then Steck.Add(ch)
  else
   begin
    Steck.Read(ch1);
    Steck.Read(ch2);
    op2:=mszn[ch1];
    op1:=mszn[ch2];
    case ch of
      '+': rez:=op1+op2;
      '-': rez:=op1-op2;
      '*': rez:=op1*op2;
      '/': rez:=op1/op2;
      '^': rez:=power(op1,op2);
    end;
    inc(ch);
    Steck.Add(ch);
    mszn[ch]:=rez;
   end;
end;
result:=rez;
Steck.Free;
end;


end.
 