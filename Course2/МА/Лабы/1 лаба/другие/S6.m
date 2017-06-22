%Область сходимости степенного ряда
%Ряд: (х-5)^n/((n+4)*ln(n+4))
syms x s n an an1 r x0 x1 x2
char res
x1 = '';
x2 = '';
assume(x, 'rational');
assume(n,'integer');
assume(n>0);
x0 = 5;
f = (x-x0)^n/((n+4)*log(n+4));
an = 1/((n+4)*log(n+4));
an1 = 1/((n+5)*log(n+5));
r = limit(abs(an1/an),n,inf);
if(r ~=inf)
    %Применим интегральный признак в граничных точках
    x = x0-r;
    s = int((abs(-1)^n/((n+4)*log(n+4))),n,1,inf);
    if(s ~= inf)
        %Если конечный, ряд сходится абсолютно
        x1 = x;
    else
        %Если не конечный, то либо расходится, либо сходится условно
        %Признка Лейбница
        if(limit(an,n,inf)==0)
            x1 = x;
        end;
    end;
    x = x0+r;
    s = int(1/((n+4)*log(n+4)),n,1,inf);
    if(s ~= inf)
        %Если конечный, ряд сходится
        x2 = x;
    end;
    %Собираем результат в строку
    res = sprintf('Область сходимости:');
    if(~isempty(x1))
        res = sprintf('%s [%d;',res,double(x1));
    else
        res = sprintf('%s (%d;',res,double(x0-r));
    end;
    if(~isempty(x2))
        res = sprintf('%s%d]',res,double(x2));
    else
        res = sprintf('%s%d)',res,double(x0+r));
    end;
    disp(res);
elseif(f == 0)
    disp('Область сходимости: {%d}',x0);
else
    disp('Область сходимости: (-inf .. inf)');
end;
%Результат: Область сходимости: [4;6)