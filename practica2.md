## Práctica 2: Introducción a los scripts y física en Unity

#### Ejercicio 1:

- **Apartado a:** Ninguno de los objetos, tanto el cubo como la esfera cae. Ambos se quedan flotando.
- ![Gif](gifs/apartadoA.mp4)
- **Apartado b:** En este apartado, el cubo se queda flotando, y por el contrario la esfera cae, chocando con el plano.
- **Apartado c:** Ambos objetos caen y chocan contra el plano.
- **Apartado d:** En este caso si ponemos el cubo debajo de la esdera, el cubo sufre una deformacion ya que la esfera lo aplasta. Luego la esfera rebota y cae para otro lado.
- **Apartado e:** He añadido un pequeño script que nos mande un mensaje cuando colisiona, y es el siguiente
```c#
void OnTriggerEnter() 
{
    Debug.Log("Is trigger");
}
```
    
Además el cubo se queda estático y la esfera cae atravesando al mismo. En el momento del impacto nos sale el mensaje en la terminal que dice **`Is trigger`**.
- **Apartado f:** Ambos caen pero la esfera se detiene al impactar con el plano, el cubo, por su parte, atraviesa el plano el plano ya que pierde sus colisiones a pesar de tener físicas. Por otra parte cuando el cubo toca el plano nos vuelve a saltar el mensaje **`Is trigger`**.

---

#### Ejercicio 2

 - **Apartado a:** Para este apartado se ha creado el script `characterController.cs` y se han añadido las siguientes lineas que comprueban si la tecla pulsada por el usuario es la indicada y en ese caso actualiza el movimiento.

```c#
void Update()
{
  if (Input.GetKey("s")) {
    gameObject.transform.Translate(0, 0, -7 * Time.deltaTime);
  }
  if (Input.GetKey("w")) {
    gameObject.transform.Translate(0, 0, 7 * Time.deltaTime);
  }
  if (Input.GetKey("a")) {
    gameObject.transform.Translate(-7 * Time.deltaTime, 0, 0);
  }
  if (Input.GetKey("d")) {
    gameObject.transform.Translate(7 * Time.deltaTime, 0, 0);
  }
}
```

- **Apartado b:** Se ha añadido una variable global que almacenará la velocidad y para actualizar este valor se ha habilitado un `Tooltip, que es una caja de texto en la cual podremos poner la velocidad a la que queramos que se mueva nuestro  personaje. El codigo añadido es el siguiente:

```c#
[Header("Personaje")]
[Tooltip("velocidad del personaje")]
public float velocidad = 2.0f;
```

- ***Apartado c:** En este ultimo apartado hemos añadido un `Tooltip` tipo booleano, que tendra dos cajitas, las cuales podremos activar o desactivar en funcion de con que teclas queramos mover el personaje. Ademas de gestionar estas decisiones mediante un if. 

```c#
[Header("Con que teclas desea mover el personaje")]
public bool wasd = true;
public bool flechas = false;

void Update()
  {
    if (wasd) {
      //codigo enseñado en el apartado a
    }
    if (flechas) {
      if (Input.GetKey("down")) {
        gameObject.transform.Translate(0, 0, -7 * Time.deltaTime * velocidad);
      }
      if (Input.GetKey("up")) {
        gameObject.transform.Translate(0, 0, 7 * Time.deltaTime * velocidad);
      }
      if (Input.GetKey("left")) {
        gameObject.transform.Translate(-7 * Time.deltaTime * velocidad, 0, 0);
      }
      if (Input.GetKey("right")) {
        gameObject.transform.Translate(7 * Time.deltaTime * velocidad, 0, 0);
      }
    }
  }
```

- **Apartado d:** Simplemente se ha cambiado el eje Z por el eje Y al crear los vectores de `transform`

---

#### Ejercicio 3

- **Apartado a:** Se ha añadido un script a los cilindros que con cada colisión se aumentará su tamaño.

```c#
void OnCollisionEnter() 
{
  //Debug.Log("colision");
  gameObject.transform.localScale += new Vector3(0.1f + Time.deltaTime, 0.1f + Time.deltaTime, 0.1f + Time.deltaTime);
}
```
- **Apartado b:** En el fichro del `characterController.cs`, se ha añadido un codigo que se activa cuando se detecta la tecla **`space`**. Una vez detectado el espacio, se creará un  array con todos los objetos con el tag **tipoA**, y calcula la distancia de cada cilindro de este tipo al **Player**. En el caso de que alguno de estos cilindros este a la distancia establecida se llamará a una funcion creada en el script `cilindroA.cs`. Esta función recibe un **gameObject**, que será el cilindro que se encuentra cerca del jugador, Y le aplica una fuerza en la dirección contraria al jugador.

```c#
if (Input.GetKeyDown("space")) {
  GameObject[] tipoA = GameObject.FindGameObjectsWithTag("tipoA");
  for (int i = 0; i < tipoA.Length; i++) {
    float distancia = Vector3.Distance(tipoA[i].transform.position, gameObject.transform.position);
    if (distancia < 10f) {
      tipoA[i].GetComponent<cilindroA>().pushCylinder(gameObject);
    }
  }
}
```
*characterController.cs*

```c#
public void pushCylinder(GameObject player) {
  Vector3 fuerzas = (gameObject.transform.position - player.transform.position) * 100;
  gameObject.GetComponent<Rigidbody>().AddForce(fuerzas);
}
```
*cilindroA.cs*

- **Apartado c:** Se han añadido cilindros **tipo B** y un script para los mismos. Al igual que en el apartado anterior, estaremos pendiente de  que los cilindros tipo B no esten en el rango del jugador. En el caso de que alguno se encuentre en el rango esta vez sin estar a la espera de que se pulse el espacio, se llamara a la funcion `pushCylinder()` del fichero `cilindroB.cs` que aplicará un empuje sobre el cilindro en la dirección contraria al jugador.
```c#
GameObject[] tipoB = GameObject.FindGameObjectsWithTag("tipoB");
  for (int i = 0; i < tipoB.Length; i++) {
    float distancia = Vector3.Distance(tipoB[i].transform.position, gameObject.transform.position);
    if (distancia < 10f) {
      tipoB[i].GetComponent<cilindroB>().pushCylinder(gameObject);
    }
  }
```
*characterController.cs*

```c#
public void pushCylinder(GameObject player) {
  Vector3 fuerzas = (gameObject.transform.position - player.transform.position) * 100;
  gameObject.GetComponent<Rigidbody>().AddForce(fuerzas);
}
```
*cilindroB.cs*

- **Apartado d:** El tercer elemento ha sido una  esfera ya que la necesitaremos para el último apartado. Estaremos atentos por si se toca alguna de las teclas aplicar el movimiento tal y como se indica en el enunciado, y detectará las colisiones con el fichero `trigger.cs`, que cuando detecte una colisión nos mandara un mensaje por la terminal.
```c#
void Update()
{
  if (Input.GetKey("l")) {
    gameObject.transform.Translate(velocidad * Time.deltaTime * 7, 0, 0);
    //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(2000 * Time.deltaTime, 0, 0));
  }
  if (Input.GetKey("j")) {
    gameObject.transform.Translate(-velocidad * Time.deltaTime * 7, 0, 0);
    //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-2000 * Time.deltaTime, 0, 0));
  }
  if (Input.GetKey("i")) {
    gameObject.transform.Translate(0, 0, 7 * velocidad * Time.deltaTime);
    //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 2000 * Time.deltaTime));
  }
  if (Input.GetKey("m")) {
    gameObject.transform.Translate(0, 0, -velocidad * Time.deltaTime * 7);
    //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -2000 * Time.deltaTime));
  }
}
```
*sphereController.cs*

```c#
void OnColissionEnter() 
{
  Debug.Log("Colission");
}
```
*trigger.cs*

- **Apartado e:** Por ultimo se ha creado el fichero `powerUp.cs` que estará atento a que los objetos con el tag **Player** y con el tag **Sphere** no esten en su rango, en caso de que player este en su rango se invocara la funcion `minim()` del fichero `characterController.cs`,  que hará al jugador, más pequeño. En caso de que Sphere sea el que este en su rango se invocará la función `maxim()` del fichero `characterController.cs` que hará al jugador más grande.

```c#
public void minim() {
  //Debug.Log("minim");
  gameObject.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
}

public void maxim() {
  gameObject.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
}
```
*characterController.cs*

```c#
void Update()
{
  GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
  for (int i = 0; i < player.Length; i++) {
    float distancia = Vector3.Distance(player[i].transform.position, gameObject.transform.position);
    if (distancia < 3f) {
      player[i].GetComponent<characterController>().minim();
    } 
  }

  GameObject[] sphere = GameObject.FindGameObjectsWithTag("Sphere");
  for (int i = 0; i < sphere.Length; i++) {
    float distancia = Vector3.Distance(sphere[i].transform.position, gameObject.transform.position);
    if (distancia < 3f) {
      player[i].GetComponent<characterController>().maxim();
    } 
  }
}
```
*powerUp.cs*
