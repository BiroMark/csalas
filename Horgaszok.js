import axios from 'axios'
import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'

export default function Horgaszok() {

    const [horgaszok, sethorgaszok] = useState([]) // [] üres tömb jel kell bele!!

    useEffect(() => {
        axios.get("https://halak.onrender.com/api/Horgaszok")
        .then(function(response) {
            sethorgaszok(response.data)
        })
    }, [])

     function HorgaszTorol(id) {
        axios.delete(`https://halak.onrender.com/api/Horgaszok/${id}`)
            .then(() => {
                alert("Sikeresen törölve!");
                navigate("/");
            })
            .catch(error => {
                console.error("Hiba történt a törlés során! ", error);
            })
    }
    

  return (
    <div>
        {
            horgaszok.map(function(horgasz) {
                return (<div class="card" style={{width: "500px"}}>
                    <img src={horgasz.kep} class="card-img-top" alt="..."/>
                    <div class="card-body">
                      <h5 class="card-title">{horgasz.nev}</h5>
                      <p class="card-text">Kor: {horgasz.eletkor}</p>
                      <Link to={"/horgasz/" + horgasz.id}>
                        <i class="bi bi-info-circle"></i>
                      </Link>
                      <i onClick={function () {
                                            if (window.confirm("Biztosan törölni szeretnéd?")) {
                                                HorgaszTorol(horgasz.id)
                                            }
                                        }}
                                            class="bi bi-trash-fill"></i>
                    </div>
                  </div>)
            })
        }
        <Link to="/uj-horgasz">
            <button>Új horgász</button>
        </Link>
    </div>
  )
}
