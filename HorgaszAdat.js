import axios from 'axios'
import { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'

export default function HorgaszAdat() {

  const [horgasz, sethorgasz] = useState({}) // {} kell bele, mert 1 db objektumot kapunk!

  const params = useParams() // kiszedi az id-t az URL-ből

  useEffect(() => {
    axios.get("https://halak.onrender.com/api/Horgaszok/" + params.id)
      .then(function (response) {
        sethorgasz(response.data)
      })
  }, [])

  return (
    <div>
      <div class="card" style={{ width: "500px" }}>
        <img src={horgasz.kep} class="card-img-top" alt="..." />
        <div class="card-body">
          <h5 class="card-title">{horgasz.nev}</h5>
          <p class="card-text">Kor: {horgasz.eletkor}</p>
        </div>
      </div>
      <Link to="/">
        <button>Vissza</button>
      </Link>
    </div>
  )
}
