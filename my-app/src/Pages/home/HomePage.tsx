import './HomeCss.css';
import joinUP from '../../assets/joinup.png'
import dzvin from '../../assets/dzvin.png'
import star from '../../assets/star.png'
import vidi from '../../assets/vidi.png'
const HomePage = () => {

    return (
      <>
          
          <div className="meny">
            <div className="Poshuk">
            <div className="krug"></div>
            <a className="PoshukLink">Пошук туру</a>
          </div>
          
            

          <nav className="top-menu">
            <a className="navbar-logo" href=""></a>
            <ul className="menu-main">
              <li><a href="">Країна</a></li>
              <li><a href="">Готелі</a></li>
              <li><a href="">Новини</a></li>
              <li><a href="">Зробити UP!</a></li>
              <li><a href="">Фрайчайзинг</a></li>
              <li><a href="">Де купити</a></li>
            </ul>
            <img src={joinUP} className='joinUp'></img>
          </nav>



            </div>
         
          
         <div className="block">
          <div className='jovti j1'>
          <img  className='dzvin' src={dzvin}></img>
          <a  className='jovtiLink jl1'>Увага туристам</a>
          </div>
          
          <div className='jovti j2'>
          <img  className='star' src={star}></img>
          <a  className='jovtiLink jl2'>Довідник</a>
          </div>
          </div>    
           

          <div className="chasVid">
            <a  className='perev'>Час прильоту</a>
          </div>
         
        

          <div className='DivVidi'>
            <img  className='Vidi' src={vidi}></img>
          </div>
          <div className='prolet'></div>
        
        
      </>
    );
}

export default HomePage;