function TitleComponent(props) {
  return (
    <div>
      <h1 className="font-bold text-center text-4xl p-4 text-grey-800">
        {props.children}
      </h1>
    </div>
  );
}

export default TitleComponent;
