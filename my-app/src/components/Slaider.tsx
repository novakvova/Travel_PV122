
import 'bootstrap/dist/css/bootstrap.min.css';
import { Carousel } from 'react-bootstrap';

import './Slaider.css'
import kartinka1 from '../assets/MainPage_Agentam_59.jpg'
import kartinka2 from '../assets/baner_Family_UKR_Web.jpg'
import kartinka3 from '../assets/Celebrate-Your-road.png'
import kartinka4 from '../assets/Montegro_1_2.jpg'
import kartinka5 from '../assets/Strani_Join-UP_6-1.jpg'
import kartinka6 from '../assets/Egypt_1_2-1.jpg'
import kartinka7 from '../assets/Cyprus-2-4.jpg'
import kartinka8 from '../assets/Cyprus_1_2.jpg'
import kartinka9 from '../assets/Spain_2_2.jpg'
import kartinka10 from '../assets/Spain-1-2.jpg'
function App() {
  return (
    <div className="container">
      <Carousel>
        <Carousel.Item>
            
          <img
          
            className="slider-image"
            src={kartinka1}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
          
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka2}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka3}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka4}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka5}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka6}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka7}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka8}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka9}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
        <Carousel.Item>
        <img
            className="slider-image"
            src={kartinka10}
            alt="First slide"
            
          />
          <div  className='bilshe'>
          <a  className="bilsheLink">Дізнатись більше</a>
          </div>
        </Carousel.Item>
      </Carousel>
    </div>
  );
}

export default App;