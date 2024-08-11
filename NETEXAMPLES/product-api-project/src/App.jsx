import { useEffect, useState } from 'react'
import axios from 'axios'

function App() {
  const [products, setProduct] = useState([])

  useEffect(()=>{
    axios.get("https://localhost:7048/api/Product")
    .then((response)=>{
      setProduct(response.data)
    })
    .catch((e) => console.log(e))
  },[])
  return (
    <>
        {
          products.map((product)=>{
            return(
              <div key={product.id}>
                {product.title}
              </div>
            )
           
          })
        }
       
    </>
  )
}

export default App
