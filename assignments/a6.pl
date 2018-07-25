% COMP3350 - a6

when_(1000,10).
when_(1200,12).
when_(3400,11).
when_(666, 12).
when_(3350,12).
when_(2350,11).
where(1000,dobbs102).
where(1200,dobbs118).
where(3400,wentw216).
where(666,wentw216).
where(3350,wentw118).
where(2350,wentw216).
enroll(mary,1200).
enroll(john,3400).
enroll(ned, 666).
enroll(mary,3350).
enroll(john,1000).
enroll(jim,1000).


/*******************************************
** define your four predicates below here **
**       leave this comment intact        **
*******************************************/

schedule(S, C, T) :-
    enroll(S, CourseN),
    where(CourseN, C),
    when_(CourseN, T).

usage(C, T) :-
    where(CourseN, C),
    when_(CourseN, T).

roomconflict(C1, C2) :-
    not(var(C1)), fail ;
    not(var(C2)), fail ;
    var(C1), var(C2),
    where(C1, R1),
    where(C2, R2),
    when_(C1, T1),
    when_(C2, T2),
    C1 \= C2,
    R1 == R2, T1 == T2.

meet(S1, S2) :-
    enroll(S1, C1),
    enroll(S2, C2),
    C1 == C2, ! ;
    enroll(S1, C1),
    enroll(S2, C2),
    where(C1, R1),
    where(C2, R2),
    R1 == R2,
    when_(C1, T1),
    when_(C2, T2),
    nearby(T1, T2), !.

nearby(X, Y) :-
    X is Y + 1 ;
    X is Y - 1 .

