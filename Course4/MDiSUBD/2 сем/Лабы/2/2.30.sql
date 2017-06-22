/* 
Базовый текст дан в отдельном файле db_text_task.txt. Для выполненияэтого блока 
заданий лучше всего объявить переменную типа varcharиприсвойте ей в качестве 
значения строку с базовым текстом, которая будет анализироваться и/или исправляться 
в заданиях. 

 Удалить  в  тексте  лишние  пробелы.  Лишними  считаются  те,  которые  идут 
непосредственно за пробелом. Подсчитать количество исправлений.  */

declare
  text varchar(6202) := 'Притчи и рассказы  с неожиданными финалами и мудростью, спрятанной  глубоко внутри, впечатляют намного больше, нежели просто умные мысли и цитаты. 

В этом материале 5  притч   , остроумные и беспощадные сюжеты    которых помогут вам как в решении деловых  проблем, так   и в преодолении трудностей, связанных лично с вами.

Жена и сосед
Муж заходит в душ в то время, как его жена только закончила мыться.Раздается дверной звонок.Жена наскоро заворачивается в полотенце и бежит открывать. На пороге — сосед Боб. Увидев её,Боб говорит:«Я дам Вам  800 долларов ,  если Вы снимете полотенце».Подумав пару секунд,   женщина делает это и стоит перед Бобом голая. Боб дает  ей 800 долларов и уходит.  Жена надевает полотенце обратно и возвращается в ванную.

— Кто  это был  ?   — спрашивает  муж.
— Боб — отвечает   жена.
— Прекрасно, —  говорит муж , — он ничего не говорил про 800 долларов, которые мне должен?

Мораль:  делитесь с акционерами информацией о выданных кредитах , иначе Вы можете оказаться в неприятной   ситуации.

Бухгалтер, секретарша,менеджер и Джинн
Бухгалтер,секретарша и менеджер  пошли обедать и нашли античную лампу .Ни на что не надеясь,они потерли ее,  и к своему удивлению увидели перед собой Джинна, заявившего:
— Я исполню по одному желанию каждого из вас.
— Я первая, я первая    ! — закричала секретарша —  Я хочу сейчас быть на Багамах , на катере, и не думать ни о чем — и исчезла.
— Теперь я, теперь я! — говорит бухгалтер — Хочу быть на Гавайях,  отдыхать на пляже,  с массажем, бесконечным запасом пина колады и любовью всей моей жизни — и тоже исчез.
— Теперь твоя   очередь, — говорит Джинн менеджеру.
— Я хочу, чтобы те двое вернулись в офис после обеда.

Мораль: всегда давайте вашему боссу высказаться первым.

Священник и монахиня
Как-то раз священник предложил монахине подвезти ее до дома   . Сев в машину,она закинула ногу за ногу так, что обнажилось бедро. Священнику с трудом удалось избежать аварии. Выровняв машину, он украдкой кладет руку ей на ногу.  Монахиня говорит :
— Отец, Вы помните Псалом 129 ?
Священник убирает руку.Но, поменяв передачу, он опять кладет руку ей на ногу. Монахиня  повторяет:
—   Отец, Вы помните Псалом 129?
Священник извиняется: 
— Простите,   сестра, но плоть слаба.

Добравшись до монастыря, монахиня тяжело вздыхает и выходит.  Приехав в церковь, священник находит Псалом 129.   В нем говорится: « Иди дальше и ищи,выше ты найдешь счастье».

Мораль: если Вы плохо знаете свою работу, многие возможности для  развития пройдут прямо у Вас перед носом.

Орел и кролик
Орел сидел на   дереве,отдыхал и ничего не делал. Маленький кролик  увидел орла и спросил:
— А можно мне  тоже сидеть,как Вы ,и ничего не делать ?
— Конечно, почему нет, — ответил тот   .
Кролик сел под деревом и стал отдыхать. Вдруг появилась лиса, схватила кролика и съела его.

Мораль:  чтобы   сидеть и ничего не делать, Вы должны  сидеть очень,  очень высоко.

Два торговца обувью в Африке
Крупная  обувная компания отправила в  командировку в Африку продавца.Через неделю он в телеграмме начальству написал следующие слова:
«Забирайте  меня отсюда. Нет никаких перспектив. Здесь все ходят босиком ! »
Через некоторое время компания решила предпринять еще одну попытку.Послали  второго продавца.
« Это большая удача !— с восторгом написал второй,—Высылайте все,что есть , рынок практически не ограничен! Здесь все ходят босиком  !»

Мораль  :  вещи сами по себе не бывают плохими или хорошими. Их делает такими наше отношение.';
  twoOrMoreWhiteSpacesRegExp varchar(5):=' {2,}';
begin
  DBMS_OUTPUT.put_line('Количество исправлений: ' || REGEXP_COUNT(text, twoOrMoreWhiteSpacesRegExp));
  DBMS_OUTPUT.put_line(REGEXP_REPLACE(text, twoOrMoreWhiteSpacesRegExp, ' '));
  
end;