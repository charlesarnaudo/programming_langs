/*
    COMP3350 lab3a - Prolog introduction
*/

/* insert your facts and rules here */

car(tesla, model_s, electric).
car(ford, f150, gas).
car(tesla, model_3, electric).
car(toyota, camry, gas).
car(nissan, leaf, electric).
car(honda, civic, gas).

isElectric(X) :-
    car(_, _, Z), Z == electric.

isTesla(X) :-
    car(X, _, Z), X == tesla, Z == electric.

betterForEnvironment(X, Y) :-
    car(X, _, A),
    car(Y, _, B), \+ A = B.


/* put your example queries in this comment under your clauses

isElectric(tesla)
isTesla(nissan)
betterForEnvironment(tesla, ford)

*/