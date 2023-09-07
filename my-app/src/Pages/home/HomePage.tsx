import './HomeCss.css';
import joinUP from '../../assets/joinup.png'
const HomePage = () => {

    return (
      <>
          
          <div className="meny">
            <div className="Poshuk">
            <div className="krug"></div>
            <a className="PoshukLink">Пошук туру</a>

            </div>
            <a className="menyLinks me1">Країна</a>
            <a className="menyLinks me2">Готелі</a>
            <a className="menyLinks me3">Новини</a>
            <a className="menyLinks me4">Зроби UP!</a>
            <a className="menyLinks me5">Франчайзинг</a>
            <a className="menyLinks me6">Де купити</a>
            
            <img src={joinUP} className="joinUp"></img>
          </div>
          
         <div className="block">    
           
         </div>
        



        
        
      </>
    );
}

export default HomePage;