module Components.Demo

open Fable.Core
open Vide
open type Html
open Components.Card
open type Card

let MyCount (count: int) = vide {
  div.class' ("my-count") { $"The current count is {count} :)" }
}

let AsyncComponent (counter: MutableValue<int>) = vide {
  return MyCount counter.Value

  do! async {
    do! Async.Sleep 500
    counter := 42
  }

  return MyCount counter.Value

  do! Promise.sleep 1000 |> Async.AwaitPromise
  counter := 100
  return MyCount counter.Value
}

let cards = vide {
  let! currentCount = Vide.ofMutable 0

  Card(
    vide {
      let! result = AsyncComponent currentCount

      p {
        $"Result is: "
        result
      }
    },
    header = vide { "Async Component" },
    footer = vide { "This is the footer" }
  )

  Card(
    vide { "This is just another Usage" },
    header = vide {
      section {
        h1 { "This is a section" }
        p { "This is a paragraph" }
      }

      section {
        h1 { "This is another section" }
        p { "This is another paragraph" }
      }
    }
  )
}

let view = vide { article.class' ("app") { main { cards } } }
