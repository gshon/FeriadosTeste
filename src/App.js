import React, { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios';
import moment from 'moment';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

function App() {

  const baseUrl = "https://localhost:7127/api/feriados";

  const [data, setData]=useState([]);

  const feriadosGet=async()=>{
    await axios.get(baseUrl + "/ObterFeriados")
    .then(response=> {
      setData(response.data);
    }).catch(console.error())
  };

  const [feriadoSelecionado,setFeriadoSelecionado]=useState({
    id:'',
    date:'',
    title:'',
    description:'',
    legislation:'',
    type:'',
    startTime:null,
    endTime:null
  })

  const handleChange = item =>{
    const {name, value}=item.target;
    setFeriadoSelecionado({
      ...feriadoSelecionado,
      [name]: value
    });
    console.log(feriadoSelecionado);
  }

  const [modalAlterar, setModalAlterar]=useState(false);
  const [modalExcluir, setModalExcluir]=useState(false);

  const abrirFecharModal=()=>{
    setModalAlterar(!modalAlterar);
  }

  const abrirFecharModalExcluir=()=>{
    setModalExcluir(!modalExcluir);
  }

  const selecionarFeriado=(feriado, opcao)=>{
    setFeriadoSelecionado(feriado);
    (opcao==="Alterar") ? abrirFecharModal() : abrirFecharModalExcluir();
  }

  const feriadoAlterar=async()=>{
    await axios.put(baseUrl+"/Atualizar", feriadoSelecionado)
    .then(response=>{
      var retorno=response.data;      
      var dadosAuxiliar=data;
      dadosAuxiliar.map(feriado=>{
        if(feriado.id===feriadoSelecionado.id){
          feriado.date = retorno.date;
          feriado.title = retorno.title;
          feriado.description = retorno.description;
          feriado.legislation = retorno.legislation;
          feriado.type = retorno.type;
          feriado.startTime = retorno.startTime;
          feriado.endTime = retorno.endTime;
        }
      });
      abrirFecharModal();
    }).catch(error=>{console.log(error)});
  }

  const feriadoExcluir=async()=>{
    await axios.post(baseUrl+"/Deletar", feriadoSelecionado)
    .then(response=>{
      setData(data.filter(feriado=>feriado.id !== response.data));      
      abrirFecharModalExcluir();
    }).catch(error=>{console.log(error)});
  }

  useEffect(()=>{
    feriadosGet();
  })

  function formatDate (datetime){

    if(!datetime)
      return null;

    return moment(datetime).format('DD/MM/YYYY HH:mm');
  };

  return (
    <div className="feriado-container">
      <br/>
      <h3>Feriados</h3>
      <header></header>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Data</th>
            <th>Titulo</th>
            <th>Descrição</th>
            <th>Legislação</th>
            <th>Tipo</th>
            <th>Hora Inicial</th>
            <th>Hora Final</th>
            <th>Opções</th>
          </tr>            
        </thead>
        <tbody>
          {data.map(feriado=>(
            <tr key={feriado.id}>
              <td>{feriado.id}</td>
              <td>{feriado.date}</td>
              <td>{feriado.title}</td>
              <td>{feriado.description}</td>
              <td>{feriado.legislation}</td>
              <td>{feriado.type}</td>
              <td>{formatDate(feriado.startTime)}</td>
              <td>{formatDate(feriado.endTime)}</td>
              <td>
                <button className='btn btn-primary' onClick={()=>selecionarFeriado(feriado, "Alterar")}>Editar</button>
                <button className='btn btn-danger' onClick={()=>selecionarFeriado(feriado, "Excluir")}>Excluir</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <Modal isOpen={modalAlterar}>
        <ModalHeader>Atualizar Feriado</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <input type="hidden" name="id" value={feriadoSelecionado && feriadoSelecionado.id}/>
            <label>Data: </label>
            <br />
            <input type="text" className="form-control" name="date" onChange={handleChange} value={feriadoSelecionado && feriadoSelecionado.date}/>
            <br/>
            <label>Titulo: </label>
            <br />
            <input type="text" className="form-control" name="title" onChange={handleChange}  value={feriadoSelecionado && feriadoSelecionado.title}/>
            <br/>
            <label>Descrição: </label>
            <br />
            <input type="text" className="form-control" name="description" onChange={handleChange} value={feriadoSelecionado && feriadoSelecionado.description}/>
            <br/>
            <label>Legislação: </label>
            <br />
            <input type="text" className="form-control" name="legislation" onChange={handleChange} value={feriadoSelecionado && feriadoSelecionado.legislation}/>
            <br/>
            <label>Tipo: </label>
            <br />
            <input type="text" className="form-control" name="type" onChange={handleChange} value={feriadoSelecionado && feriadoSelecionado.type}/>
            <br/>
            <label>Hora Inicio: </label>
            <br />
            <input type="datetime-local" className="form-control" name="startTime" onChange={handleChange} value={feriadoSelecionado && feriadoSelecionado.startTime}/>
            <br/>
            <label>Hora Final: </label>
            <br />
            <input type="datetime-local" className="form-control" name="endTime" onChange={handleChange} value={feriadoSelecionado && feriadoSelecionado.endTime}/>
            <br/>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={()=>feriadoAlterar()}>Salvar</button>{"    "}
          <button className="btn btn-danger" onClick={()=>abrirFecharModal()} >Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalExcluir}>
        <ModalBody>
          Confirma a exclusão do Feriado {feriadoSelecionado.title} da base?
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-danger" onClick={()=>feriadoExcluir()}>Sim</button>
          <button className="btn btn-secondary" onClick={()=>abrirFecharModalExcluir()}>Não</button>
        </ModalFooter>
      </Modal>

    </div>
  );
}

export default App;
