// namespace A3
// 
// open System
// module A3 =
//     type SET =
//        | I of int list                                  // I [1;2;3]
//        | S of string list                               // S ["a";"b";"c"]
//        | IS of (int * string) list                      // IS [(1, "a");(2, "b")]
//        | II of (int * int) list                         // II [(1,2); (3,4); (5,6)]
//        | SS of (string * string) list                   // SS [("a","b"); ("c","d")]
//        | SI of (string * int) list                      // SI [("a", 1); ("b", 2); ("c", 3)]
//        | SISI of ((string * int) * (string * int)) list // SISI [(("a", 1), ("b", 2)); (("c", 3), "d", 4))]
//        | SIIS of ((string * int) * (int * string)) list // SIIS [(("a", 1), (2, "b")); (("c", 3), (4, "d"))]
// 
//     // Copied from lab3
//     let rec dist a L = 
//       match L with
//       | [] -> []
//       | _ -> (a, L.Head)::(dist a L.Tail)
// 
//     // Copy your definition from lab3
//     let rec pairs s1 s2 = 
//       match s1 with
//       | [] -> []
//       | _ -> (dist s1.Head s2)@(pairs s1.Tail s2)
// 
//     // Copy your definition from lab3
//     let product s1 s2 =
//       match (s1, s2) with
//         | (I s1, I s2) -> II (pairs s1 s2)
//         | (S s1, S s2) -> SS (pairs s1 s2)
//         | (I s1, S s2) -> IS (pairs s1 s2)
//         | (S s1, I s2) -> SI (pairs s1 s2)
//         | (SI s1, IS s2) -> SIIS (pairs s1 s2)
//         | (SI s1, SI s2) -> SISI (pairs s1 s2)
//     
//     let rec isMember a L =
//       match L with
//         | [] -> false
//         | h::t when a=h -> true
//         | h::t -> isMember a t
// 
//     let rec unionList l1 l2 =
//       match l1 with
//         | [] -> l2
//         | h::t when not (isMember h l2) -> h::unionList t l2
//         | h::t -> unionList t l2
// 
//     let union s1 s2 =
//       match (s1, s2) with
//         | (I l1, I l2) -> I (unionList l1 l2)
//         | (IS l1, IS l2) -> IS (unionList l1 l2)
//         | (SISI l1, SISI l2) -> SISI (unionList l1 l2)
//         | (SI l1, SI l2) -> SI (unionList l1 l2)
//         | (SIIS l1, SIIS l2) -> SIIS (unionList l1 l2) 
//     
//     let gtIx x (a, _) = a > x
//     let gtxxxI x ((_, _), (_, a)) = a > x
//     
//     // Take string x and a tuple who's first element is a string
//     // compares length
//     let gtSx (x : string) (a : string, _) = x.Length > a.Length
// 
//     // Takes int x and a tuple of tuples, whose first tuple has a second element that is an int
//     let eqxIxx (x : int) ((_, a : int), (_, _)) = x = a
// 
//     let rec filter f L =
//         match L with
//           | [] -> []
//           | h::t when f h -> h::filter f t
//           | h::t -> filter f t
// 
//     let selectIS s f =
//         match s with
//           | IS i -> IS (filter f i)
// 
//     let selectSISI s f =
//         match s with
//           | SISI i -> SISI (filter f i)
// 
//     // Selects from set s of type SI using function f
//     let selectSI s f = 
//       match s with 
//       | SI i -> SI (filter f i)
// 
//     // Selects from set s of type SIIS using function f
//     let selectSIIS s f = 
//       match s with
//       | SIIS i -> SIIS (filter f i)
// 
//     // Takes two lists
//     // loops through l1, checking if head element is in l2
//     // when l1.head is not in l2, that element is appeneded to other elements not in l2
//     // dif is all elemenets in l1 NOT in l2
//     let rec difList l1 l2 =
//       match l1 with
//       | [] -> []
//       | h::t when (isMember l1.Head l2) -> (difList l1.Tail l2)
//       | h::t when not (isMember l1.Head l2) -> l1.Head::(difList l1.Tail l2)
//         
//     // You should match a pattern with SI and SIIS and compute the difference of the sets
//     let difference s1 s2 = 
//       match (s1, s2) with
//       | (I l1, I l2) -> I (difList l1 l2)
//       | (IS l1, IS l2) -> IS (difList l1 l2)
//       | (SISI l1, SISI l2) -> SISI (difList l1 l2)
//       | (SI l1, SI l2) -> SI (difList l1 l2)
//       | (SIIS l1, SIIS l2) -> SIIS (difList l1 l2) 
// 
// // Anonymous comparators
// let i1 = I [1111;2222;3333]
// let i2 = I [5555; 6666]
// let s1 = S ["COMP"; "HIST"; "PHYS"]
// let s2 = S ["CHEM"; "MATH"]
// let is = product i1 s1
// let si1 = product s1 i1
// let si2 = product s2 i2
// let sisi = product si1 si2
// let siis1 = product si1 is
// let siis2 = product si2 is
// selectSI si1 (fun (a : string, _) -> a.Length > "COMP".Length) // REPLACE gtSx
// selectSIIS siis1 (fun ((_, a : int), (_, _)) -> a = 2222)   // REPLACE eqIxx