import axios from "axios";
import { useNavigate } from "react-router-dom";


export default function UjHorgasz() {

  const navigate = useNavigate();

  function Post() {
    let adatok = {
      nev: document.getElementById("nev").value,
      eletkor: Number(document.getElementById("eletkor").value)
    }

    axios.post("https://halak.onrender.com/api/Horgaszok", adatok)
    .then(function() {
      alert("Sikeres adatfelvitel!");
      navigate("/");
    })
    .catch(function(error) {
      console.error("Hiba: ", error);
    })

  }

  return (
    <div>
      <h1>Új horgász felvitele</h1>
      <form onSubmit={function(e) {
        e.preventDefault();
        Post();
      }}>
        <label>Név: </label><br />
        <input type="text" id="nev" /><br />
        <label>Életkor: </label><br />
        <input type="number" id="eletkor"/><br />
        <button type="submit">Felvisz</button>
      </form>
    </div>
  )
}
