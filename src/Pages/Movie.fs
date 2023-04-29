module Pages.Movie

open Fable.Core
open Vide
open type Html

let View (id: string) = vide { h1 { $"Movie Page: {id}" } }
